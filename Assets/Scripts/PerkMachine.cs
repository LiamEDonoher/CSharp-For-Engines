using UnityEngine;
using UnityEngine.InputSystem;

public class PerkMachine : MonoBehaviour
{
    /*private InputAction m_Interact;
    private bool isPlayerDetected;
    private GameObject m_Player;
    private PlayerStats m_PlayerStats;
    
    private void Start()
    {
        //m_Interact = InputSystem.actions.FindAction("Interact");
        isPlayerDetected = false;
    }

    private void Update()
    {
        if (isPlayerDetected && m_Interact.triggered)
        {
            if (m_PlayerStats.points >= 2000)
                BuyUpgrade();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerDetected = true;
            m_PlayerStats = collision.GetComponent<PlayerStats>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerDetected = false;
            m_PlayerStats = null;
        }
    }

    private void BuyUpgrade()
    {
        m_PlayerStats.points -= 2000;
        print("Perk Baught!");
    }*/
}
