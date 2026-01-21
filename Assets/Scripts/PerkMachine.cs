using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class PerkMachine : MonoBehaviour
{
    [SerializeField] GameObject m_player;
    private float m_playerDistance;


    private void Update()
    {
        m_playerDistance = Vector2.Distance(m_player.transform.position, transform.position);
        print(m_playerDistance);
        if (m_playerDistance > 3)
            print("Test");
        return;
    }

}