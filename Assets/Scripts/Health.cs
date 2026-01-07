using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image m_healthBar;

    [SerializeField] private float m_maxHealth = 100;
    private float m_currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_currentHealth = m_maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // We use floats to find the percentage of health rather than the value.
        m_healthBar.fillAmount = m_currentHealth / m_maxHealth;

    }
}
