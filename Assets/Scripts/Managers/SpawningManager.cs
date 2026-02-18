using System;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [SerializeField] private PlayerStats m_stats;
    [SerializeField] private GameObject m_zombiePrefab;
    [SerializeField] private Transform[] m_spawnPoints;
    private Transform m_currentSpawnPoint;
    private float m_cooldownDuration = 12f;
    private float m_spawnTimer;
    private float m_minPlayerDistance;

    void Start()
    {
        m_stats.m_wave = 1;
        StartWave();

    }

    private void Update()
    {
        m_spawnTimer = Time.deltaTime;

        if (m_spawnTimer <= 0f)
        {
            SpawnZombie();
            m_spawnTimer = m_cooldownDuration;
        }
    }

    private void StartWave()
    {

    }

    private void SpawnZombie()
    {
        Transform m_spawnPoint = GetRandomSpawnPoint();
        GameObject m_zombie = Instantiate(m_zombiePrefab, m_spawnPoint.position, Quaternion.identity);
        print("Zombie Spawned");
    }

    private Transform GetRandomSpawnPoint()
    {
        int chosenSpawn = UnityEngine.Random.Range(0, m_spawnPoints.Length);
        return m_spawnPoints[chosenSpawn];
    }
}
