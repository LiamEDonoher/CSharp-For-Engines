using UnityEngine;

public class CrosshairAnim : MonoBehaviour
{
    [SerializeField] private Sprite[] m_crosshairArray;
    private Animator m_animator;
    private SpriteRenderer m_spriteRenderer;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Changes the crosshair sprite.
    /// </summary>
    public void CrosshairUpdate(int m_weaponID)
    {
        print("Test");
        for (int i = 0; i < m_crosshairArray.Length; i++)
        {
            if (i == m_weaponID)
            {
                m_spriteRenderer.sprite = m_crosshairArray[i];
                break;
            }
        }
    }


}
