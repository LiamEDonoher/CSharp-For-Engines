using Unity.VisualScripting;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] float lifeTime = 5f;

    private void Update()
    {
        if (lifeTime > 0)
            lifeTime = lifeTime - Time.deltaTime;
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }

        
    }
}
