using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image m_healthBar;
    [SerializeField] private float m_maxHealth = 100;
    [SerializeField] private ParticleSystem m_bloodEffect;
    private PlayerStats m_stats;

    private float m_currentHealth;
    private bool m_canRevive;


    private void Start()
    {
        m_currentHealth = m_maxHealth;
        m_canRevive = false;
}
    public void TakeDamage(float m_damage)
    {
        m_currentHealth -= m_damage;
        m_healthBar.fillAmount = m_currentHealth / m_maxHealth;
        m_bloodEffect.Play();

        if ((m_currentHealth <= 0) && (m_canRevive == true))
        {
            m_currentHealth = m_maxHealth / 2;
            m_canRevive = false;
            m_stats.LosePerk(1);
        }
        else if ((m_currentHealth <= 0) && (m_canRevive == false))
        {
            SceneManager.LoadScene("DeathScreen");
        }
        

    }

    public void HealPlayer()
    {
        m_currentHealth += (m_currentHealth / 4);
    }

    /// <summary>
    /// Triggers jug perk.
    /// </summary>
    public void HealthBuff()
    {
        m_maxHealth = m_maxHealth + 100;
        HealPlayer(); 
    }

    /// <summary>
    /// Triggers revive perk.
    /// </summary>
    public void ReviveBuff()
    {
        m_canRevive = true;
    }
}

