using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private Image m_blackScreen;
    private float m_fadeDuration = 2.5f;

    private void Start()
    {
        m_blackScreen.canvasRenderer.SetAlpha(0f);
    }

    /// <summary>
    /// Fades the screen to black.
    /// </summary>
    public void FadeToBlack()
    {
        m_blackScreen.canvasRenderer.SetAlpha(0f);
        m_blackScreen.CrossFadeAlpha(1f, m_fadeDuration, false);
    }

    /// <summary>
    /// Fades the screen from black.
    /// </summary>
    public void FadeFromBlack()
    {
        m_blackScreen.canvasRenderer.SetAlpha(1f);
        m_blackScreen.CrossFadeAlpha(0f, m_fadeDuration, false);
    }
}
