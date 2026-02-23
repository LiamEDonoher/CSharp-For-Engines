using UnityEngine;

public class PowerSwitch : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_managers;
    private PlayerStats m_playerStats;
    private ParticleSystem m_particles;
    private AudioSource m_powerOnSound;



    [Header("Settings")]
    private float m_distanceToPlayer;

    private void Start()
    {
        m_playerStats = m_player.GetComponent<PlayerStats>();
        m_particles = m_player.GetComponent<ParticleSystem>();
        m_powerOnSound = m_player.GetComponent<AudioSource>();
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
            m_powerOnSound.Play();
        }
    }

}