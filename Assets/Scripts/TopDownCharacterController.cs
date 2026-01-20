using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Variables

    //The inputs that we need to retrieve from the input system.
    private InputAction m_moveAction;
    private InputAction m_attackAction;

    //The components that we need to edit to make the player move smoothly.
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;

    //The direction that the player is moving in.
    private Vector2 m_playerDirection;


    [Header("Movement parameters")]
    //The speed at which the player moves
    [SerializeField] private float m_playerSpeed = 200f;
    //The maximum speed the player can move
    [SerializeField] private float m_playerMaxSpeed = 1000f;

    #endregion

    [Header("Projectile Parameters")]

    [SerializeField] private GameObject m_projectilePrefab;
    [SerializeField] private Transform m_firePoint;
    [SerializeField] private UnityEngine.UI.Image m_reloadBar;
    [SerializeField] private float m_projectileSpeed;
    [SerializeField] private float m_cooldownTimer;
    [SerializeField] private Vector2 m_direction;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] GameObject _aimCursor;
    bool m_canFire = true;
    private float m_currentCooldown;


    public void HandleAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && Time.time > m_currentCooldown)
        {
            m_currentCooldown = m_cooldownTimer;
            Fire();
        }

        if (m_canFire == false)
        {
            m_currentCooldown -= Time.deltaTime;
            if (m_currentCooldown < 0)
            {
                m_canFire = true;
            }
        }
    }


    private void Awake()
    {
        //bind movement inputs to variables
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_attackAction = InputSystem.actions.FindAction("Attack");

        //get components from Character game object so that we can use them later.
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();

        //m_GameInput = new InputSystem_Actions();
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
        m_rigidbody.linearVelocity = m_playerDirection * (speed * Time.fixedDeltaTime);
    }


    void Update()
    {

        // store any movement inputs into m_playerDirection - this will be used in FixedUpdate to move the player.
        m_playerDirection = m_moveAction.ReadValue<Vector2>();
        m_playerDirection.Normalize();

        // ~~ handle animator ~~
        // Update the animator speed to ensure that we revert to idle if the player doesn't move.
        m_animator.SetFloat("Speed", m_playerDirection.magnitude);

        // If there is movement, set the directional values to ensure the character is facing the way they are moving.
        if (m_playerDirection.magnitude > 0)
        {
            m_animator.SetFloat("Horizontal", m_playerDirection.x);
            m_animator.SetFloat("Vertical", m_playerDirection.y);
        }




    }

    private void Fire()
    {
        m_canFire = false;
        Vector2 firingPos = m_firePoint.position;
        m_firePoint.position = firingPos;

        GameObject spawnedProjectile = Instantiate(m_projectilePrefab, m_firePoint.position, Quaternion.identity);

        Rigidbody2D projectileRB = spawnedProjectile.GetComponent<Rigidbody2D>();
        if (projectileRB != null)
        {
            spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(m_direction.normalized * m_projectileSpeed, ForceMode2D.Impulse);
        }

    }

    private void AimMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotateSpeed * Time.fixedDeltaTime);
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _aimCursor.transform.position = cursorPos;
    }    
}
