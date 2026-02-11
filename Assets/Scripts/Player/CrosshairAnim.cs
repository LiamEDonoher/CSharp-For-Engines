using UnityEngine;

public class CrosshairAnim : MonoBehaviour
{
    private Animator m_animator;
    [SerializeField] private WeaponManager m_weaponManager;

    public string m_crosshairAnimation;
    public string m_reloadAnimation;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_crosshairAnimation = m_weaponManager.m_crosshairAnimation;
        m_reloadAnimation = m_weaponManager.m_reloadAnimation;
    }

    /// <summary>
    /// Plays the crosshair reload animation.
    /// </summary>
    public void ReloadAnim()
    {
        m_animator.Play(m_reloadAnimation, 0, 0f);
    }

}
