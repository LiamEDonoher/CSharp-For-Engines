using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class PlayerInteraction : MonoBehaviour
{
    /*
    [SerializeField] private GameObject m_powerSwitch;
    //private PlayerStats m_PlayerStats;
    //private bool isInteractDetected;
    //private int m_cost;
    private float lastBuyTime;
    private Collider2D m_interactable;

    private void Start()
    {
        isInteractDetected = false;
        m_PlayerStats = GetComponent<PlayerStats>();
    }




    public void TryInteract()
    {
        if (!isInteractDetected)
        {
            return;
        }
        if (m_interactable.tag == ("PowerSwitch"))
        {
            TurnOnPower();
        }
        else if (m_interactable.tag == ("Barrier"))
        {
            return;
            //FixBarrier();
        }
        else if (m_interactable.tag == ("Wallbuy"))
        {
            TryPurchase();
        }

    }


    private void TryPurchase()
    {

        if (Time.time < lastBuyTime + 8f)
        {
            return;
        }

        if (m_PlayerStats.m_points < m_cost)
        {
            return;
        }

        m_PlayerStats.m_points -= m_cost;
        lastBuyTime = Time.time;
    }

    private void TurnOnPower()
    {
        if (m_PlayerStats.m_powerOn == true)
        {
            print("Power is already on");
            return;
        }

        print("Power is turning on");
        m_PlayerStats.m_powerOn = true;
        m_powerSwitch_anim.Play("PowerOn");
    }*/

    

    public void TryInteract()
    {

    }
}

