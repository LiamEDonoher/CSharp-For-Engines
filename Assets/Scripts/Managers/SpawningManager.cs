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
    private int m_spawnCount;

    void Start()
    {
        m_stats.m_wave = 1;
        m_spawnCount = 0;
    }

    private void Update()
    {
        if (m_spawnCount < m_waveSize)
        {
            m_spawnTimer -= Time.deltaTime;

            if (m_spawnTimer <= 0f)
            {
                SpawnZombie(m_player);
                m_spawnTimer = m_cooldownDuration;
            }
        }
        int m_zombiesRemaining = FindObjectsOfType<EnemyController>().Length;
        if  ((m_zombiesRemaining <= 0) && (m_spawnCount >= m_waveSize))
        {
            NewWave();
        }
        

    }

    private void SpawnZombie(GameObject m_player)
    {
        m_spawnCount += 1;
        Transform m_spawnPoint = GetRandomSpawnPoint();
        GameObject m_zombie = Instantiate(m_zombiePrefab, m_spawnPoint.position, Quaternion.identity);
        EnemyController m_spawnedZombie = m_zombie.GetComponent<EnemyController>();
        m_spawnedZombie.Initialise(m_player);
    }

    private Transform GetRandomSpawnPoint()
    {
        int chosenSpawn = UnityEngine.Random.Range(0, m_spawnPoints.Length);
        return m_spawnPoints[chosenSpawn];
    }

    private void NewWave()
    {
        m_stats.m_wave += 1;
        m_spawnCount = 0;
        if (m_waveSize < 30)
        {
            m_waveSize += 3;
        }
    }
}
