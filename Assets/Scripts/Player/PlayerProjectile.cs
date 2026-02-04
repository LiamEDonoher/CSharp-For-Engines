using Unity.VisualScripting;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float m_lifeTime = 5f;
    [SerializeField] private PlayerStats m_player;
    private EnemyController m_enemy;
    private float m_bulletDamage;

// Destroy bullet if it is alive too long
    private void Update()
    {
        if (m_lifeTime > 0)
            m_lifeTime = m_lifeTime - Time.deltaTime;
        else
            Destroy(gameObject);
    }

    public void Initialise(PlayerWeapon m_owner, PlayerStats m_playerStats, float m_weaponDamage)
    {
        m_player = m_playerStats;
        m_bulletDamage = m_weaponDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            m_enemy = other.GetComponent<EnemyController>();
            m_enemy.TakeDamage(m_bulletDamage);
            m_player.AddPoints(10);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }

            
        

        
    }
}
