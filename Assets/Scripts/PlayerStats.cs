using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private TMP_Text m_text;
    public int m_points;
    public bool m_powerOn;

    private void Start()
    {
        m_powerOn = false;
    }



    private void Awake()
    {
        m_points = 2000;
    }

    private void Update()
    {
        m_text.text = m_points.ToString();
    }
}
