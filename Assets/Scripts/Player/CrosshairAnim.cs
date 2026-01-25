using UnityEngine;

public class CrosshairAnim : MonoBehaviour
{
    private Animator m_animator;
    private WeaponManager m_weaponManager;

    public string m_crosshairAnimation;
    public string m_reloadAnimation;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_weaponManager = GetComponent<WeaponManager>();
        m_crosshairAnimation = m_weaponManager.m_crosshairAnimation;
        m_reloadAnimation = m_weaponManager.m_reloadAnimation;
    }

    public void ReloadAnim() // Feed in current weapon when gun switching is set up
    {
        m_animator.Play(m_reloadAnimation, 0, 0f);
    }

}
