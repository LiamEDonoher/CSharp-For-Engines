using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform m_Player;
    public float m_speed;
    public float m_stoppingDistance;
    private float m_playerDistance;
    bool m_PlayerInSight;



    private void Start()
    {
        m_Player = FindObjectOfType<TopDownCharacterController>().transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, m_Player.position) >= m_stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Player.position, m_speed * Time.deltaTime);
        }
    }

    enum EnemyStates
    {
        Distracted,
        MoveToPlayer,
        Attack
    }

    private void Distracted()
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
            m_PlayerInSight = true;
            m_playerDistance = Vector3.Distance(collision.transform.position, transform.position);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_PlayerInSight = false;
    }
}


// Make it so if they can't say the player they will be pinged with the lpayers exact location every (10s/waveCount) capped at 1s