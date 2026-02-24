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
        m_particles = GetComponent<ParticleSystem>();
        m_powerOnSound = GetComponent<AudioSource>();
    }


    public void Update()
    {
        m_distanceToPlayer = Vector3.Distance(transform.position, m_player.transform.position);
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (m_distanceToPlayer > 3)
            {
                print("2");
                return;
            }

            m_playerStats.m_powerOn = true;
            m_particles.Play();
            m_powerOnSound.Play();
        }
    }

}