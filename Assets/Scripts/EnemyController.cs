using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private Animator m_animator;
    public Transform m_Player;
    public Vector2 m_direction;
    public float m_speed;
    public float m_stoppingDistance;
    private float m_playerDistance;
    bool m_playerInSight;



    private void Start()
    {
        m_Player = FindObjectOfType<TopDownCharacterController>().transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, m_Player.position) >= m_stoppingDistance)
        {
            Vector2 m_currentPosition = transform.position;
            Vector2 m_targetPosition = m_Player.position;
            transform.position = Vector2.MoveTowards(m_currentPosition, m_targetPosition, m_speed * Time.deltaTime);
            
            m_direction = (m_targetPosition - m_currentPosition).normalized;
            
        }
    }


    enum EnemyStates
    {
        Barrier,
        MoveToPlayer,
        Attack
    }

    private void Barrier()
    {
        return;
    }

    private void Attack()
    {
        if (m_playerDistance <= 1)
        {
            print("ATTACKING!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            m_playerInSight = true;
            m_playerDistance = Vector3.Distance(collision.transform.position, transform.position);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_playerInSight = false;
    }
}


// Make it so if they can't say the player they will be pinged with the lpayers exact location every (10s/waveCount) capped at 1s