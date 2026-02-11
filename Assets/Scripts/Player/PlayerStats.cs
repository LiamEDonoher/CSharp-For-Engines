using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private TMP_Text m_text;
    public int m_points;
    public bool m_powerOn;
    private int m_perkID;
    private PlayerHealth m_health;
    private bool[] m_perks = new bool[3];
    

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

    public void AddPoints(int m_pointsIncrease)
    {
        m_points += m_pointsIncrease;
    }

    /// <summary>
    /// Disables all perks by default and turns them on when the perk is purchased.
    /// </summary>
    /// <param name="m_perkID"></param>
    public void TriggerPerk(int m_perkID)
    {
        for (int i = 0; i < m_perks.Length; i++)
        {
            m_perks[i] = false;
        }

        m_perks[m_perkID] = true;

        if (m_perkID == 0)
        {
            return;
        }
        else if (m_perkID == 1)
        {
            m_health.HealthBuff();
        }
        else if (m_perkID == 2)
        {
            m_health.ReviveBuff();
        }
        else
        {
            return;
        }
    }
    public void LosePerk(int m_perkID)
    {
        m_perks[m_perkID] = false;
    }
}
