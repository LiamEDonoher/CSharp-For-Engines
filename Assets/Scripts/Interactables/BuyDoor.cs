using UnityEngine;

public class BuyDoor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_managers;
    [SerializeField] private int m_doorID;
    private PlayerStats m_playerStats;
    private float m_distanceToPlayer;


    [Header("Settings")]
    private int m_doorCost = 2000;


    private void Start()
    {
        m_playerStats = m_player.GetComponent<PlayerStats>();
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

            if (m_playerStats.m_points < m_doorCost)
            {
                return;
            }

            print("Door Purchased");
            m_playerStats.m_points -= m_doorCost;
            Destroy(gameObject);

        }
    }

}