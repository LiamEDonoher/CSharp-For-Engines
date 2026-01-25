using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image m_healthBar;
    [SerializeField] private float m_maxHealth = 100;
    [SerializeField] private ParticleSystem m_bloodEffect;

    private float m_currentHealth;


    private void Start()
    {
        m_currentHealth = m_maxHealth;
    }
    public void TakeDamage(float m_damage)
    {
        m_currentHealth -= m_damage;
        m_healthBar.fillAmount = m_currentHealth / m_maxHealth;
        m_bloodEffect.Play();

        if (m_currentHealth <= 0)
        {
            return;
            //Destroy(gameObject);
        }

    }

}

