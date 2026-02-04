using Unity.VisualScripting;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer m_treeTop;
    [SerializeField] SpriteRenderer m_treeBase;

    void Start()
    {
        m_treeBase.enabled = true;
        m_treeTop.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_treeBase.enabled = false;
        m_treeTop.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_treeBase.enabled = true;
        m_treeTop.enabled = false;
    }
}
