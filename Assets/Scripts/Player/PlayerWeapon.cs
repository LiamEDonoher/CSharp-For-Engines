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
    private InputAction m_attackAction;
    private PlayerStats m_playerStats;
    private Vector2 m_aimDirection;
    private CrosshairAnim m_cursorAnim;
    private WeaponManager m_weaponManager;
    [Header("Modifiers")]
    private float m_projectileSpeed = 30f;
    private float m_cooldownTimer;
    private float m_nextFireTime;
    private string m_crosshairAnimation;
    private string m_reloadAnimation;
    private float m_weaponDamage;



    private void Start()
    {
        m_weaponManager = GetComponent<WeaponManager>();
        m_weaponManager.Revolver();
        UpdateWeapon();


        UnityEngine.Cursor.visible = false;
        m_cursorAnim = m_aimCursor.GetComponent<CrosshairAnim>();
    }
    private void Update()
    {
        AimMouse();
    }

    private void Awake()
    {
        m_attackAction = InputSystem.actions.FindAction("Attack");
        m_attackAction.Enable();
        m_impulseSource = GetComponent<CinemachineImpulseSource>();
        m_playerStats = GetComponent<PlayerStats>();
    }


    public void HandleAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && Time.time > m_nextFireTime)
        {
            Fire();
            m_nextFireTime = Time.time + m_cooldownTimer;
        }
    }

    private void Fire()
    {
        CameraShakeManager.instance.CameraShake(m_impulseSource);
        GameObject spawnedProjectile = Instantiate(m_projectilePrefab, m_firePoint.position, Quaternion.identity);
        PlayerProjectile m_instantiatedProjectile = spawnedProjectile.GetComponent<PlayerProjectile>();
        m_instantiatedProjectile.Initialise(this, m_playerStats, m_weaponDamage);

        Rigidbody2D projectileRB = spawnedProjectile.GetComponent<Rigidbody2D>();
        if (projectileRB != null)
        {
            spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(m_aimDirection.normalized * m_projectileSpeed, ForceMode2D.Impulse);
            m_cursorAnim.ReloadAnim();
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

        m_aimCursor.transform.position = mousePos;

    }

    private void UpdateWeapon()
    {
        m_cooldownTimer = m_weaponManager.m_cooldownTimer;
        m_reloadAnimation = m_weaponManager.m_crosshairAnimation;
        m_crosshairAnimation = m_weaponManager.m_crosshairAnimation;
        m_weaponDamage = m_weaponManager.m_weaponDamage;
    }
}
