using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] GameObject[] powerUps;

    [SerializeField] Transform tankTop;

    [SerializeField] List<GameObject> powerUpsList;

    public List<GameObject> PowerUpsList { get => powerUpsList; set => powerUpsList = value; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
