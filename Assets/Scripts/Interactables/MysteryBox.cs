using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerStats m_playerStats;
    [SerializeField] private GameObject m_player;

    [Header("Settings")]
    private int m_buyCost = 750;
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

            if (m_playerStats.m_points < m_buyCost)
            {
                print("Not enough points");
                return;
            }

            print("Weapon Purchased");
            m_playerStats.m_points -= m_buyCost;
        }
    }


}