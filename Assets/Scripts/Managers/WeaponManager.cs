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
    private SpriteRenderer m_weaponSprite;
    private PlayerWeapon m_playerWeapon;
    public Sprite[] m_spriteArray;
    private CrosshairAnim m_crosshairAnim;

    //[SerializeField] private GameObject m_projectilePrefab;
    [SerializeField] GameObject m_aimCursor;
    [SerializeField] private GameObject m_currentWeapon;
    //[SerializeField] private float m_projectileSpeed;

    private void Start()
    {
        m_weaponSprite = m_currentWeapon.GetComponent<SpriteRenderer>();
        m_playerWeapon = m_currentWeapon.GetComponent<PlayerWeapon>();
        m_crosshairAnim = GetComponent<CrosshairAnim>();
        Revolver();

    }



// IF TIME ADD GUNS SHOOTING AND RELOADING ANIMATIONS (NOT URGENT)

    /// <summary>
    /// Switches the player weapon to the revolver.
    /// </summary>
    public void Revolver()
    {
        print("Revolver");
        m_weaponSprite.sprite = m_spriteArray[0];
        m_playerWeapon.m_cooldownTimer = 1.2f;
        m_playerWeapon.m_weaponDamage = 20;
        m_crosshairAnim.CrosshairUpdate(0); // Updates the crosshair in script
    }

    /// <summary>
    /// Switches the player weapon to the shotgun.
    /// </summary>
    public void Shotgun()
    {
        print("Shotgun");
        m_weaponSprite.sprite = m_spriteArray[1];
        m_playerWeapon.m_cooldownTimer = 2f;
        m_playerWeapon.m_weaponDamage = 80;
        m_crosshairAnim.CrosshairUpdate(1);
    }


}
