using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private GameObject m_text;
    public int points;
    


    private void Start()
    {
        points = 2000;
        
    }
}
