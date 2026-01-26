using UnityEngine;
using UnityEngine.InputSystem;


public class TopDownCharacterController : MonoBehaviour
{
    [Header("Movement parameters")]
    [SerializeField] private float m_playerSpeed = 2f;
    [SerializeField] private float m_playerMaxSpeed = 5f;

    private InputAction m_moveAction;
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;
    private Vector2 m_moveDirection;
    private PlayerStats m_playerStats;


    private void Awake()
    {
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_moveAction.Enable();
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_playerStats = GetComponent<PlayerStats>();
    }


    private void FixedUpdate()
    {
        float speed = m_playerSpeed > m_playerMaxSpeed ? m_playerMaxSpeed : m_playerSpeed;
        m_rigidbody.linearVelocity = m_moveDirection * speed;
    }

    void Update()
    {
        m_moveDirection = m_moveAction.ReadValue<Vector2>().normalized;
        m_animator.SetFloat("Speed", m_moveDirection.magnitude);

        if (m_moveDirection.magnitude > 0)
        {
            m_animator.SetFloat("Horizontal", m_moveDirection.x);
            m_animator.SetFloat("Vertical", m_moveDirection.y);
        }
    }

}


