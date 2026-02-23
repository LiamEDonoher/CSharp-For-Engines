using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Variables")]
    public float m_weaponDamage;
    public float m_cooldownTimer;
    private SpriteRenderer m_weaponSprite;
    public Sprite[] m_spriteArray;
    public AudioClip[] m_weaponSound;
    private bool m_staminaBuff;

    [Header("References")]
    [SerializeField] GameObject m_aimCursor;
    [SerializeField] private GameObject m_currentWeapon;
    [SerializeField] private AudioSource m_weaponSoundSource;
    [SerializeField] private PlayerWeapon m_playerWeapon;


    private void Start()
    {
        m_weaponSprite = m_currentWeapon.GetComponent<SpriteRenderer>();
        m_staminaBuff = false; // Makes sure the player starts without the perk.
        Revolver();
    }

    /// <summary>
    /// Triggers stamina perk.
    /// </summary>
    public void StaminaBuff()
    {
        m_staminaBuff = true;
    }

    // IF TIME ADD GUNS SHOOTING AND RELOADING ANIMATIONS (NOT URGENT)

    /// <summary>
    /// Switches the player weapon to the revolver.
    /// </summary>
    public void Revolver()
    {
        print("Revolver");
        m_weaponSprite.sprite = m_spriteArray[0];
        //m_crosshairSprite.sprite = m_revolverSprite;
        m_weaponSoundSource.Stop();
        m_weaponSoundSource.volume = 0.3f;
        m_weaponSoundSource.clip = m_weaponSound[0];
        m_playerWeapon.m_weaponDamage = 20;
        if (m_staminaBuff)
        {
            m_playerWeapon.m_cooldownTimer = 0.8f;
        }
        else
        {
            m_playerWeapon.m_cooldownTimer = 1.2f;
        }
    }

    /// <summary>
    /// Switches the player weapon to the shotgun.
    /// </summary>
    public void Shotgun()
    {
        print("Shotgun");
        m_weaponSprite.sprite = m_spriteArray[1];
        //m_crosshairSprite.sprite = m_shotgunSprite;
        m_weaponSoundSource.Stop();
        m_weaponSoundSource.volume = 0.8f;
        m_weaponSoundSource.clip = m_weaponSound[1];
        m_playerWeapon.m_weaponDamage = 200;
        if (m_staminaBuff)
        {
            m_playerWeapon.m_cooldownTimer = 1.2f;
        }
        else
        {
            m_playerWeapon.m_cooldownTimer = 2f;
        }
    }
}