using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private TMP_Text m_text;
    [SerializeField] private PerkUI m_perkUI;
    [SerializeField] private GameObject m_powerDoor;   
    [SerializeField] private WeaponManager m_weaponManager;   
    public int m_points;
    public bool m_powerOn;
    public int m_wave;
    private int m_perkID;
    private PlayerHealth m_health;
    private bool[] m_perks = new bool[3];
    public float m_enemyHealth = 100;

    [Header("Settings")]
    [SerializeField] private SpriteRenderer m_staminaIcon;
    [SerializeField] private SpriteRenderer m_healthIcon;
    [SerializeField] private SpriteRenderer m_reviveIcon;



    private void Start()
    {
        m_powerOn = true;
        m_staminaIcon.enabled = false;
        m_healthIcon.enabled = false;
        m_reviveIcon.enabled = false;
    }

    private void Update()
    {
        m_text.text = m_points.ToString();
        if (m_powerOn)
        {
            Destroy(m_powerDoor);
        }
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
            m_weaponManager.StaminaBuff();
            m_staminaIcon.enabled = true;
        }
        else if (m_perkID == 1)
        {
            m_health.HealthBuff();
            m_healthIcon.enabled = true;
        }
        else if (m_perkID == 2)
        {
            m_health.ReviveBuff();
            m_reviveIcon.enabled = true;
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
