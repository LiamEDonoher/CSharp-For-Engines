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
    [SerializeField] GameObject m_aimCursor;
    private CinemachineImpulseSource m_impulseSource;
    private PlayerStats m_playerStats;
    private Vector2 m_aimDirection;

    private WeaponManager m_weaponManager;
    [Header("Modifiers")]
    private float m_projectileSpeed = 30f;
    public float m_cooldownTimer = 1.2f; 
    private float m_nextFireTime;
    public string m_crosshairAnimation;
    public string m_reloadAnimation;
    public float m_weaponDamage = 20;
    [SerializeField] public GameObject m_currentWeapon;



    private void Start()
    {
        m_weaponManager = GetComponent<WeaponManager>();
        UnityEngine.Cursor.visible = false;
    }
    private void Update()
    {
        AimMouse();

        if (Input.GetKeyDown(UnityEngine.KeyCode.Mouse0))
        {
            if (Time.time > m_nextFireTime)
            {
                Fire();
                m_nextFireTime = Time.time + m_cooldownTimer;
            }
        }
    }

    private void Awake()
    {
        m_impulseSource = GetComponent<CinemachineImpulseSource>();
        m_playerStats = GetComponent<PlayerStats>();
    }


    private void Fire()
    {
        //CameraShakeManager.instance.CameraShake(m_impulseSource);
        GameObject spawnedProjectile = Instantiate(m_projectilePrefab, m_firePoint.position, Quaternion.identity);
        PlayerProjectile m_instantiatedProjectile = spawnedProjectile.GetComponent<PlayerProjectile>();
        m_instantiatedProjectile.Initialise(this, m_playerStats, m_weaponDamage);

        Rigidbody2D projectileRB = spawnedProjectile.GetComponent<Rigidbody2D>();
        if (projectileRB != null)
        {
            spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(m_aimDirection.normalized * m_projectileSpeed, ForceMode2D.Impulse);
            //m_cursorAnim.ReloadAnim(); TRIGGER CROSSHAIR ANIMATION
        }
    }



    [SerializeField] private Transform gunArm;
    [SerializeField] private SpriteRenderer gun;

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
            gun.flipX = false;
            m_weaponPivot.transform.position = new Vector3(firePos.x + 1.0f, firePos.y, 0);
            angle = Mathf.Atan2(m_aimDirection.y, m_aimDirection.x) * Mathf.Rad2Deg;
        }
        else
        {
            gun.flipX = true;
            m_weaponPivot.transform.position = new Vector3(firePos.x + -1.0f, firePos.y, 0);
            angle = Mathf.Atan2(m_aimDirection.y, m_aimDirection.x) * Mathf.Rad2Deg - 180.0f;
        }


        m_currentWeapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        m_aimCursor.transform.position = new Vector3 (mousePos.x, mousePos.y, 0);
        
    }

}
