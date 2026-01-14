using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// A class to control the top-down character.
/// Implements the player controls for moving and shooting.
/// Updates the player animator so the character animates based on input.
/// </summary>
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

    /// <summary>
    /// When the script first initialises this gets called.
    /// Use this for grabbing components and setting up input bindings.
    /// </summary>
    /// 

    [Header("Projectile Parameters")]

    [SerializeField] private GameObject m_projectilePrefab;
    [SerializeField] private Transform m_firePoint;
    [SerializeField] private Image m_reloadBar;
    [SerializeField] private float m_projectileSpeed;
    [SerializeField] private float m_cooldownTimer;
    [SerializeField] private Vector2 m_direction;
    bool can_fire = true;
    private float currentCooldown;


    private void Awake()
    {
        //bind movement inputs to variables
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_attackAction = InputSystem.actions.FindAction("Attack");

        //get components from Character game object so that we can use them later.
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Called after Awake(), and is used to initialize variables e.g. set values on the player
    /// </summary>
    void Start()
    {
        currentCooldown = m_cooldownTimer;
        //not currently used - left here for demonstration purposes.
    }

    /// <summary>
    /// When a fixed update loop is called, it runs at a constant rate, regardless of pc performance.
    /// This ensures that physics are calculated properly.
    /// </summary>
    private void FixedUpdate()
    {
        //clamp the speed to the maximum speed for if the speed has been changed in code.
        float speed = m_playerSpeed > m_playerMaxSpeed ? m_playerMaxSpeed : m_playerSpeed;

        //apply the movement to the character using the clamped speed value.
        m_rigidbody.linearVelocity = m_playerDirection * (speed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// When the update loop is called, it runs every frame.
    /// Therefore, this will run more or less frequently depending on performance.
    /// Used to catch changes in variables or input.
    /// </summary>
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

        // check if an attack has been triggered.
        if ((m_attackAction.WasPressedThisFrame()) && (can_fire == true))
        {
            currentCooldown = m_cooldownTimer;
            Fire(); 
        }

        if (can_fire == false)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown < 0)
            {
                can_fire = true;
            }
        }
    }

    private void Fire()
    {
        can_fire = false;
        Vector2 firingPos = m_firePoint.position;
        m_firePoint.position = firingPos;

        GameObject spawnedProjectile = Instantiate(m_projectilePrefab, m_firePoint.position, Quaternion.identity);

        Rigidbody2D projectileRB = spawnedProjectile.GetComponent<Rigidbody2D>();
        if (projectileRB != null)
        {
            spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(m_direction.normalized * m_projectileSpeed, ForceMode2D.Impulse);
        }

    }
}
