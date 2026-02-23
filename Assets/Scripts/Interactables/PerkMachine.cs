using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class PerkMachine : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerStats m_playerStats;
    [SerializeField] private GameObject m_player;
    [SerializeField] private Material m_powerOff;
    [SerializeField] private Material m_powerOn;
    private SpriteRenderer m_spriteRenderer;
    private AudioSource m_purchaseSource;

    [Header("Settings")]
    [SerializeField] private int m_perkID;
    private int m_perkCost = 4000;
    private float m_distanceToPlayer;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_purchaseSource = GetComponent<AudioSource>();
        m_spriteRenderer.material = m_powerOff;
    }



    public void Update()
    {

        if (m_playerStats.m_powerOn == true)
        {
            m_spriteRenderer.material = m_powerOn;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            m_distanceToPlayer = Vector3.Distance(transform.position, m_player.transform.position);

            if (m_playerStats.m_powerOn == false)
            {
                return;
            }

            if (m_distanceToPlayer > 3)
            {
                print("Too far away");
                return;
            }

            if (m_playerStats.m_points < m_perkCost)
            {
                print("Not enough points");
                return;
            }

            m_purchaseSource.Play();
            m_playerStats.m_points -= m_perkCost;
            m_playerStats.TriggerPerk(m_perkID);
        }
    }


}