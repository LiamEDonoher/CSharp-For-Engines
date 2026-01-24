using UnityEngine;
using Unity.Cinemachine;

// Made referencing https://www.youtube.com/watch?v=CgyLIWyDXqo

public class CameraShakeManager : MonoBehaviour
{
    public static CameraShakeManager instance;

    [SerializeField] private float globalShakeForce = 10f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CameraShake(CinemachineImpulseSource m_impulseSource)
    {
        m_impulseSource.GenerateImpulseWithForce(globalShakeForce);
    }
}
