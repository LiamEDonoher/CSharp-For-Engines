using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class EnemyController : MonoBehaviour
{

    private Animator m_animator;
    public Transform m_target;
    NavMeshAgent m_agent;
    public Vector2 m_direction;
    public float m_speed;
    private float m_playerDistance;
    private bool m_canAttack;
    private float m_cooldownTime;
    private Rigidbody2D m_rigidBody;

    private float m_health;



    private void Start()
    {
        m_target = FindObjectOfType<TopDownCharacterController>().transform;
        m_agent = GetComponent<NavMeshAgent>();
        m_rigidBody = GetComponent<Rigidbody2D>();

        m_agent.stoppingDistance = 2f;
        m_cooldownTime = 30f;
        m_health = 10;
    }

    // Update is called once per frame

    void Update()
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


    private void AttackPlayer()
    {
        if (!m_canAttack)
        {
            m_cooldownTime -= 1;
            if (m_cooldownTime < 0)
            {
                m_canAttack = true;
            }
            return;
        }
        print("attacking player");
        
    }


    public void TakeDamage(float m_damage)
    {
        m_health -= m_damage;

        if (m_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    


}



