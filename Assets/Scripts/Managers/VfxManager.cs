using System.Collections;
using UnityEngine;
using static UnityEditor.ShaderData;

public class VfxManager : MonoBehaviour
{
    [SerializeField] private GameObject m_explosionPrefab;




    public static VfxManager s_instance;

    private void Awake()
    {
        if (s_instance == null)
            s_instance = this;
    }

    public static GameObject CreateExplosion(Vector3 position, float destroyAfter = 0.5f)
    {

        // If no explosion, kick up a fuss
        if (s_instance == null)
        {
            Debug.LogError("Tried to spawn an explosion but the instance hasn't been set.");
            return null;
        }

        // Ohterwise, spawn the explosion
        GameObject explosion = Instantiate(s_instance.m_explosionPrefab, position, Quaternion.identity);

        // Destroy the explosion after a certain amount of time
        Destroy(explosion, destroyAfter);

        // Return a ref to explosion
        return explosion;
    }
       
}

