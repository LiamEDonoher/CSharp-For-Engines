using System.Collections;
using UnityEngine;
using static UnityEditor.ShaderData;

public class ExplosionTest : MonoBehaviour
{
    [SerializeField, Range(0.01f, 1f)] private float m_explosionFrequency = 0.1f;
    [SerializeField, Range(0.5f, 4f)] private float m_explosionRadius = 0.5f;

    private void Awake()
    {
        StartCoroutine(ExplosionSpawner());
    }

    //public void Start()
    //{
    // StartCoroutine(ExplosionSpawner());
    //}

    private IEnumerator ExplosionSpawner()
    {
        while (true)
        {
            // Wait
            yield return new WaitForSeconds(m_explosionFrequency);

            // Find the position to spawn the explosion at.
            Vector3 explosionPos = transform.position;
            explosionPos += (Vector3)UnityEngine.Random.insideUnitCircle.normalized * m_explosionRadius;

            // Spawn an explosion
            VfxManager.CreateExplosion(explosionPos);
        }
    }
}

