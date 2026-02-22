using UnityEngine;

public class PowerSwitch : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_managers;
    private PlayerStats m_playerStats;
    private ParticleSystem m_particles;



    [Header("Settings")]
    private int m_weaponCost = 1200;
    private float m_distanceToPlayer;

    private void Start()
    {
        m_playerStats = m_player.GetComponent<PlayerStats>();
        m_particles = m_player.GetComponent<ParticleSystem>();
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

            m_playerStats.m_powerOn = true;
            m_particles.Play();
        }
    }

}