using JetBrains.Annotations;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float m_weaponDamage;
    public float m_cooldownTimer;
    public string m_crosshairAnimation = "RevolverCrosshair";
    public string m_reloadAnimation = "RevolverReload";
    private SpriteRenderer m_weaponSprite;
    private PlayerWeapon m_playerWeapon;
    public Sprite[] m_spriteArray;
    
    //[SerializeField] private GameObject m_projectilePrefab;
    [SerializeField] GameObject m_aimCursor;
    [SerializeField] private GameObject m_currentWeapon;
    //[SerializeField] private float m_projectileSpeed;

    private void Start()
    {
        m_weaponSprite = m_currentWeapon.GetComponent<SpriteRenderer>();
        m_playerWeapon = m_currentWeapon.GetComponent<PlayerWeapon>();
        Revolver();

    }



// IF TIME ADD GUNS SHOOTING AND RELOADING ANIMATIONS (NOT URGENT)

    public void Revolver()
    {
        print("Revolver");
        m_weaponSprite.sprite = m_spriteArray[0];
        m_playerWeapon.m_cooldownTimer = 1.2f;
        m_crosshairAnimation = "RevolverCrosshair";
        m_reloadAnimation = "RevolverReload";
        m_playerWeapon.m_weaponDamage = 20;
    }

    public void Shotgun()
    {
        print("Shotgun");
        m_weaponSprite.sprite = m_spriteArray[1];
        m_playerWeapon.m_cooldownTimer = 2f;
        m_crosshairAnimation = "ShotgunCrosshair";
        m_reloadAnimation = "ShotgunReload";
        m_playerWeapon.m_weaponDamage = 80;
    }


}
