using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float m_weaponDamage;
    public float m_cooldownTimer;
    public string m_crosshairAnimation;
    public string m_reloadAnimation;
    private Animation m_weaponSprite;
    
    //[SerializeField] private GameObject m_projectilePrefab;
    [SerializeField] GameObject m_aimCursor;
    [SerializeField] private GameObject m_currentWeapon;
    //[SerializeField] private float m_projectileSpeed;

    private void Start()
    {
        m_weaponSprite = m_currentWeapon.GetComponent<Animation>();
    }



// IF TIME ADD GUNS SHOOTING AND RELOADING ANIMATIONS (NOT URGENT)

    public void Revolver()
    {
        m_weaponSprite.Play("Revolver");
        m_cooldownTimer = 1.2f;
        m_crosshairAnimation = "RevolverCrosshair";
        m_reloadAnimation = "RevolverReload";
        m_weaponDamage = 20;
    }

    public void Shotgun()
    {
        m_weaponSprite.Play("Shotgun");
        m_cooldownTimer = 2f;
        m_crosshairAnimation = "ShotgunCrosshair";
        m_reloadAnimation = "ShotgunReload";
        m_weaponDamage = 80;
    }


}
