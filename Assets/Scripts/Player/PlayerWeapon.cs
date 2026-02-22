using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Definitions")]
    [SerializeField] private GameObject m_projectilePrefab;
    [SerializeField] private Transform m_firePoint;
    [SerializeField] private Transform m_weaponPivot;
    [SerializeField] Transform m_gunPos;
    [SerializeField] GameObject m_aimCursor;
    private Animator m_cursorAnimator;
    private PlayerStats m_playerStats;
    private Vector2 m_aimDirection;
    private SpriteRenderer m_weaponRenderer;
    private AudioSource m_weaponSound;

    [Header("Modifiers")]
    private float m_projectileSpeed = 30f;
    public float m_cooldownTimer = 1.2f;
    private float m_nextFireTime;
    public float m_weaponDamage = 20;
    [SerializeField] public GameObject m_currentWeapon;



    private void Start()
    {
        m_cursorAnimator = m_aimCursor.GetComponent<Animator>();
        UnityEngine.Cursor.visible = false; // Hides the player cursor so no overlap with crosshair
        m_weaponRenderer = m_currentWeapon.GetComponent<SpriteRenderer>();
        m_weaponSound = m_currentWeapon.GetComponent<AudioSource>();
    }
    private void Update()
    {
        AimMouse();

        if (Input.GetKeyDown(UnityEngine.KeyCode.Mouse0))
        {
            if (Time.time > m_nextFireTime)
            {
                Fire();
                m_cursorAnimator.Play("ReloadAnimation", 0, 0f);
                m_nextFireTime = Time.time + m_cooldownTimer;
            }
        }
    }


    private void Awake()
    {
        m_playerStats = GetComponent<PlayerStats>();
    }


    private void Fire()
    {
        m_weaponSound.Play();
        GameObject m_spawnedProjectile = Instantiate(m_projectilePrefab, m_gunPos.position, Quaternion.identity);
        PlayerProjectile m_instantiatedProjectile = m_spawnedProjectile.GetComponent<PlayerProjectile>();
        m_instantiatedProjectile.Initialise(this, m_playerStats, m_weaponDamage);

        Rigidbody2D projectileRB = m_spawnedProjectile.GetComponent<Rigidbody2D>();
        if (projectileRB != null)
        {
            m_spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(m_aimDirection.normalized * m_projectileSpeed, ForceMode2D.Impulse);
        }
    }

    ///<summary>Makes gun shoot towards hitmarker.< /summary >
    private void AimMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 firePos = m_firePoint.position;

        m_aimDirection = mousePos - firePos;
        m_aimDirection = m_aimDirection.normalized;
        float angle = 0.0f;

        if (mousePos.x > firePos.x) // Is the gun on the right?
        {
            m_weaponRenderer.flipX = false;
            m_weaponPivot.transform.position = new Vector3(firePos.x + 1.0f, firePos.y, 0);
            angle = Mathf.Atan2(m_aimDirection.y, m_aimDirection.x) * Mathf.Rad2Deg;
        }
        else
        {
            m_weaponRenderer.flipX = true;
            m_weaponPivot.transform.position = new Vector3(firePos.x + -1.0f, firePos.y, 0);
            angle = Mathf.Atan2(m_aimDirection.y, m_aimDirection.x) * Mathf.Rad2Deg - 180.0f;
        }


        m_currentWeapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        m_aimCursor.transform.position = new Vector3 (mousePos.x, mousePos.y, 0);
        
    }

}
