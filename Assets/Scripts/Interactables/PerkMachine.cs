using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class PerkMachine : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerStats m_playerStats;
    [SerializeField] private GameObject m_player;

    [Header("Settings")]
    private int m_perkCost = 4000;
    private float m_distanceToPlayer;





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

            if (m_playerStats.m_points < m_perkCost)
            {
                print("Not enough points");
                return;
            }

            print("Perk Purchased");
            m_playerStats.m_points -= m_perkCost;
        }
    }


}