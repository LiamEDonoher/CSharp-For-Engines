using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject m_menuPanel;
    [SerializeField] private GameObject m_controlsPanel;
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button ControlsButton;
    [SerializeField] private Button QuitButton;
    private bool m_controlsPanelOpen = false;



    public void ToggleControlsPanel()
    {
        if (m_controlsPanelOpen)
        {
            m_menuPanel.SetActive(true);
            m_controlsPanel.SetActive(false);
        }
        else
        {
            m_menuPanel.SetActive(false);
            m_controlsPanel.SetActive(true);
        }
        m_controlsPanelOpen = !m_controlsPanelOpen;

    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Room1");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Start()
    {

        PlayButton.onClick.AddListener(LoadLevel);
        ControlsButton.onClick.AddListener(ToggleControlsPanel);
        QuitButton.onClick.AddListener(Quit);
    }
}
