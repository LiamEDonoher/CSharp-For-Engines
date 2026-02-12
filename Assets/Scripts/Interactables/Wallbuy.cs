using UnityEngine;

public class WallBuy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject m_player;
    [SerializeField] private int m_buyDoorIndex;
    [SerializeField] private GameObject m_managers;
    private WeaponManager m_weaponManager;
    private PlayerStats m_playerStats;



    [Header("Settings")]
    private int m_weaponCost = 1200;
    private float m_distanceToPlayer;

    private void Start()
    {
        m_playerStats = m_player.GetComponent<PlayerStats>();
        m_weaponManager = m_managers.GetComponent<WeaponManager>();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_distanceToPlayer = Vector3.Distance(transform.position, m_player.transform.position);

            if (m_distanceToPlayer > 3)
            {
                return;
            }

            if (m_playerStats.m_points < m_weaponCost)
            {
                return;
            }

            print("Weapon Purchased");
            m_playerStats.m_points -= m_weaponCost;

            if (m_buyDoorIndex == 1)
            {
                m_weaponManager.Shotgun();
            }
        }
    }

}