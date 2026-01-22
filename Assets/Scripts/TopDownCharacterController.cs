using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Variables

    //The inputs that we need to retrieve from the input system.
    private InputAction m_moveAction;
    private InputAction m_attackAction;
    private InputAction m_interact;
    

    //The components that we need to edit to make the player move smoothly.
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;

    //The direction that the player is moving in.


    [Header("Movement parameters")]
    //The speed at which the player moves
    [SerializeField] private float m_playerSpeed = 2f;
    //The maximum speed the player can move
    [SerializeField] private float m_playerMaxSpeed = 5f;

    #endregion

    [Header("Projectile Parameters")]

    [SerializeField] private GameObject m_projectilePrefab;
    [SerializeField] private Transform m_firePoint;
    [SerializeField] private UnityEngine.UI.Image m_reloadBar;
    [SerializeField] private float m_projectileSpeed;
    [SerializeField] private Transform m_weaponPivot;
    [SerializeField] private float m_cooldownTimer;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] GameObject _aimCursor;
    private float m_currentCooldown;
    private float m_nextFireTime;
    private Vector2 m_aimDirection;
    private Vector2 m_moveDirection;


    


    public void HandleAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && Time.time > m_nextFireTime)
        {
            Fire();
            m_nextFireTime = Time.time + m_cooldownTimer;
        }
    }


    private void Awake()
    {
        //bind movement inputs to variables
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_moveAction.Enable();
        m_attackAction = InputSystem.actions.FindAction("Attack");
        m_attackAction.Enable();
        m_interact = InputSystem.actions.FindAction("Interaction");
        m_interact.Enable();


        //get components from Character game object so that we can use them later.
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        m_currentCooldown = m_cooldownTimer;
        Cursor.visible = false;
    }


    private void FixedUpdate()
    {
        //clamp the speed to the maximum speed for if the speed has been changed in code.
        float speed = m_playerSpeed > m_playerMaxSpeed ? m_playerMaxSpeed : m_playerSpeed;

        //apply the movement to the character using the clamped speed value.
        m_rigidbody.linearVelocity = m_moveDirection * speed;
    }


    void Update()
    {

        // store any movement inputs into m_playerDirection - this will be used in FixedUpdate to move the player.
        m_moveDirection = m_moveAction.ReadValue<Vector2>().normalized;
        AimMouse();


        // ~~ handle animator ~~
        // Update the animator speed to ensure that we revert to idle if the player doesn't move.
        m_animator.SetFloat("Speed", m_moveDirection.magnitude);

        // If there is movement, set the directional values to ensure the character is facing the way they are moving.
        if (m_moveDirection.magnitude > 0)
        {
            m_animator.SetFloat("Horizontal", m_moveDirection.x);
            m_animator.SetFloat("Vertical", m_moveDirection.y);
        }

    }

    private void Fire()
    {
        //m_canFire = false;
        Vector2 firingPos = m_firePoint.position;
        m_firePoint.position = firingPos;

        GameObject spawnedProjectile = Instantiate(m_projectilePrefab, m_firePoint.position, Quaternion.identity);

        Rigidbody2D projectileRB = spawnedProjectile.GetComponent<Rigidbody2D>();
        if (projectileRB != null)
        {
            spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(m_aimDirection.normalized * m_projectileSpeed, ForceMode2D.Impulse);
        }

    }

    private void AimMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 firePos = m_firePoint.position;

        m_aimDirection = mousePos - firePos;
        m_aimDirection = m_aimDirection.normalized;


        float angle = Mathf.Atan2(m_aimDirection.y, m_aimDirection.x) * Mathf.Rad2Deg - 90f;
        m_weaponPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        _aimCursor.transform.position = mousePos;
        
    }

}
