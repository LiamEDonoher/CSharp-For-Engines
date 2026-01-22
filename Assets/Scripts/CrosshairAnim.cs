using UnityEngine;

public class CrosshairAnim : MonoBehaviour
{
    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    public void ReloadAnim() // Feed in current weapon when gun switching is set up
    {
        m_animator.Play("RevolverReload");
    }

}
