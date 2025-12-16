using System.Net;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Transform m_startWaypoint;
    [SerializeField] private Transform m_endWaypoint;
    [SerializeField] private float m_speed = 5;
    private bool target = false;

    private Transform m_target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        m_target = m_startWaypoint;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = m_target.position - transform.position;
        transform.Translate(direction * m_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovingObstacleWaypoint"))
        {
            ChangeTarget();
        }
    }

    void ChangeTarget()
    {
        target = !target;
        if (target == true)
        {
            direction = EndPoint.position - position;
        }
        else
        {
            direction = StartPoint.position - position;
        }
    }
}