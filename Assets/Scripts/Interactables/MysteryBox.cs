using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_managers;
    [SerializeField] private SpriteRenderer m_boxUI;
    private WeaponManager m_weaponManager;
    private PlayerStats m_playerStats;
    private AudioSource m_purchaseSound;


    [Header("Settings")]
    private int m_weaponCost = 750;
    private float m_distanceToPlayer;

    private void Start()
    {
        m_playerStats = m_player.GetComponent<PlayerStats>();
        m_weaponManager = m_managers.GetComponent<WeaponManager>();
        m_purchaseSound = GetComponent<AudioSource>();
        m_boxUI.enabled = false;
    }


    public void Update()
    {
        m_distanceToPlayer = Vector3.Distance(transform.position, m_player.transform.position);
        if (m_distanceToPlayer > 3)
        {
            m_boxUI.enabled = false;
            return;
        }
        else
        {
            m_boxUI.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {

                if (m_playerStats.m_powerOn == false)
                {
                    return;
                }

                if (m_playerStats.m_points < m_weaponCost)
                {
                    return;
                }

                m_purchaseSound.Play();
                m_playerStats.m_points -= m_weaponCost;
                GenerateWeapon();
            }
        }
    }

    private void GenerateWeapon()
    {
        int weaponSelect = Random.Range(0, 2);

        if (weaponSelect == 0)
        {
            m_weaponManager.Revolver();
            print("Revolver");
        }
        else if (weaponSelect == 1)
        {
            m_weaponManager.Shotgun();
            print("Shotgun");
        }

    }
}