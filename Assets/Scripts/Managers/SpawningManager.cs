using System;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [SerializeField] private PlayerStats m_stats;
    [SerializeField] private GameObject m_zombiePrefab;
    [SerializeField] private GameObject m_player;
    [SerializeField] private Transform[] m_spawnPoints;
    private Transform m_currentSpawnPoint;
    private float m_cooldownDuration = 12f;
    private float m_spawnTimer;
    private float m_minPlayerDistance;
    private int m_waveSize = 8;

    void Start()
    {
        m_stats.m_wave = 1;
        StartWave();

    }

    private void Update()
    {
        m_spawnTimer -= Time.deltaTime;

        if (m_spawnTimer <= 0f)
        {
            SpawnZombie(m_player);
            m_spawnTimer = m_cooldownDuration;
        }
    }

    private void StartWave()
    {
        
    }

    private void SpawnZombie(GameObject m_player)
    {
        Transform m_spawnPoint = GetRandomSpawnPoint();
        GameObject m_zombie = Instantiate(m_zombiePrefab, m_spawnPoint.position, Quaternion.identity);
        EnemyController m_spawnedZombie = m_zombie.GetComponent<EnemyController>();
        m_spawnedZombie.Initialise(m_player);
        print("Zombie Spawned");
    }

    private Transform GetRandomSpawnPoint()
    {
        int chosenSpawn = UnityEngine.Random.Range(0, m_spawnPoints.Length);
        return m_spawnPoints[chosenSpawn];
    }
}
