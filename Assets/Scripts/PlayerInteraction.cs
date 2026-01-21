using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerStats m_PlayerStats;
    private bool isInteractDetected;
    private int cost;
    private bool buySuccess;
    private float lastBuyTime;

    private void Start()
    {
        isInteractDetected = false;
        m_PlayerStats = GetComponent<PlayerStats>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PerkMachine")
        {
            isInteractDetected = true;
            cost = 4000;
        }
        if (collision.tag == "Wallbuy")
        {
            isInteractDetected = true;
            cost = 1200;
        }
        if (collision.tag == "PowerSwitch")
        {
            isInteractDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PerkMachine")
        {
            isInteractDetected = false;
        }
        if (collision.tag == "Wallbuy")
        {
            isInteractDetected = false;
        }
        if (collision.tag == "PowerSwitch")
        {
            isInteractDetected = false;
        }
    }


    public void TryInteract()
    {
        if (!isInteractDetected)
        {
            return;
        }

        if (Time.time < lastBuyTime + 8f)
        {
            return;
        }

        if (m_PlayerStats.points < cost)
        {
            return;
        }

        m_PlayerStats.points -= cost;
        lastBuyTime = Time.time;
    }
}

