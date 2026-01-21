using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private TMP_Text m_text;
    public int points;
    


    private void Awake()
    {
        points = 2000;
    }

    private void Update()
    {
        m_text.text = points.ToString();
    }
}
