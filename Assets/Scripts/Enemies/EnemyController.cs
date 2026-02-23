using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private AudioSource m_spawnSound;

    GameObject m_player;
    PlayerStats m_playerStats;
    NavMeshAgent m_agent;

    private Animator m_animator;
    public Transform m_target;
    public Vector2 m_direction;
    public float m_speed;
    public float m_cooldownTime; // Slow down enemy attack speed as waves go up to subtly help the player
    private float m_playerDistance;
    private bool m_canAttack;
    private Rigidbody2D m_rigidBody;
    private PlayerHealth m_healthHandler;
    private float m_health = 100;
    private AudioSource m_attackSound;

    private void Start()
    {
        m_attackSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (m_target)
        {
            float distance = Vector3.Distance(transform.position, m_target.position);

            if (distance > 3f)
            {
                m_rigidBody.bodyType = RigidbodyType2D.Dynamic;
                m_agent.isStopped = false;
                m_agent.autoRepath = false;
                m_agent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
                m_agent.SetDestination(m_target.position);

            }
            else
            {
                m_agent.isStopped = true;
                m_rigidBody.linearVelocity = Vector3.zero;
                m_rigidBody.bodyType = RigidbodyType2D.Kinematic;
                m_agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
                AttackPlayer();
            }
        }
    }


    private void AttackPlayer()
    {
        if (!m_canAttack)
        {
            m_cooldownTime -= 1;
            if (m_cooldownTime < 0)
            {
                m_healthHandler.TakeDamage(10);
                m_canAttack = true;

            }
            return;
        }
        m_attackSound.pitch = Random.Range(0.8f, 1.2f);
        m_attackSound.Play();
        m_cooldownTime = 200f;
        m_canAttack = false;
    }


    public void TakeDamage(float m_damage)
    {
        m_health -= m_damage;
        m_playerStats.AddPoints(10);

        if (m_health <= 0)
        {
            m_playerStats.AddPoints(100);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Gives each spawned enemy the info it needs to function.
    /// </summary>
    /// <param name="m_player"></param>
    public void Initialise(GameObject m_player)
    {
        m_target = m_player.transform;
        m_playerStats = m_player.GetComponent<PlayerStats>();
        m_healthHandler = m_player.GetComponent<PlayerHealth>();
        m_agent = GetComponent<NavMeshAgent>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_cooldownTime = 100f;
        m_health = m_playerStats.m_enemyHealth;
        m_agent.stoppingDistance = 2f;
        m_spawnSound.pitch = Random.Range(0.8f, 1.4f);
    }
}