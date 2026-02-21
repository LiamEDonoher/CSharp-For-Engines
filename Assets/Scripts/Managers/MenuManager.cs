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
    [SerializeField] private Button ReturnButton;
    [SerializeField] private Button QuitButton;
    private bool m_controlsPanelOpen = false;


 

    public void OpenControlsPanel()
    {
        m_controlsPanel.SetActive(true);
        m_menuPanel.SetActive(false);
        m_controlsPanelOpen = true;
    }

    public void CloseControlsPanel()
    {
        m_menuPanel.SetActive(true);
        m_controlsPanel.SetActive(false);
        m_controlsPanelOpen = false;
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
        ControlsButton.onClick.AddListener(OpenControlsPanel);
        ReturnButton.onClick.AddListener(CloseControlsPanel);
        QuitButton.onClick.AddListener(Quit);
        m_menuPanel.SetActive(true);
        m_controlsPanel.SetActive(false);
        m_controlsPanelOpen = false;
    }
}
