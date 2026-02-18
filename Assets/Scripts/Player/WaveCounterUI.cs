using TMPro;
using UnityEngine;

public class WaveCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_text;
    [SerializeField] private PlayerStats m_playerStats;



    void Update()
    {
        m_text.text = m_playerStats.m_wave.ToString();
    }
}
