using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Transform m_startWaypoint;
    [SerializeField] private Transform m_endWaypoint;
    [SerializeField] private float m_speed = 5;

    privatee Transform m_target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        m_target = m_startWaypoint; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = Transform.position;
        position.y = Transform.position.y + 0.1f;
        Transform.position = position;
    }
}
