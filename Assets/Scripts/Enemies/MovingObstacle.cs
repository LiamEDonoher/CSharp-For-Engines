using System.Net;
using Unity.VisualScripting;
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
    //private bool target = false;

    private Transform m_target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        m_target = m_endWaypoint;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_target.position, m_speed * Time.deltaTime);
        if (transform.position == m_target.position)
            ChangeTarget();
    }


    void ChangeTarget()
    {
        if (m_target == m_startWaypoint)
            m_target = m_endWaypoint;
        else
            m_target = m_startWaypoint;
    }
}