using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wallbuy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject m_player;   
    [SerializeField] private int m_wallbuyIndex;
    private PlayerStats m_playerStats;
    private WeaponManager m_weaponManager;


    [Header("Settings")]
    private int m_weaponCost = 1200;
    private float m_distanceToPlayer;

    private void Start()
    {
        m_playerStats = m_player.GetComponent<PlayerStats>();
        m_weaponManager = m_player.GetComponent<WeaponManager>();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_distanceToPlayer = Vector3.Distance(transform.position, m_player.transform.position);

            if (m_distanceToPlayer > 3)
            {
                print("Too far away");
                return;
            }

            if (m_playerStats.m_points < m_weaponCost)
            {
                print("Not enough points");
                return;
            }

            print("Weapon Purchased");
            m_playerStats.m_points -= m_weaponCost;

            if (m_wallbuyIndex == 1)
            {
                m_weaponManager.Shotgun();
            }
        }
    }

}