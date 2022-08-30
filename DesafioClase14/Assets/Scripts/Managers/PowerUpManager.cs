using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class PowerUpManager : MonoBehaviour
{
    [SerializeField] GameObject[] powerUps;

    [SerializeField] Transform tankTop;

    [SerializeField] List<GameObject> powerUpList;
    public List<GameObject> PowerUpList { get => powerUpList; set => powerUpList = value; }

    public GameObject PowerUpShield;

    private Queue powerUpQueue;
    public Queue PowerUpQueue { get => powerUpQueue; set => powerUpQueue = value; }
    
    private Stack powerUpStack;
    public Stack PowerUpStack { get => powerUpStack; set => powerUpStack = value; }
    public Dictionary<string, GameObject> PowerUpDirectory { get => powerUpDirectory; set => powerUpDirectory = value; }

    private Dictionary<string, GameObject> powerUpDirectory;




    // Start is called before the first frame update
    void Start()
    {
        powerUpQueue = new Queue();
        powerUpList = new List<GameObject>();
        powerUpStack = new Stack();
        powerUpDirectory = new Dictionary<string, GameObject>();
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipPowerUp(powerUpDirectory["Shield"]);            
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipPowerUp(powerUpDirectory["Health"]);
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipPowerUp(powerUpDirectory["Bullet"]);
        if (Input.GetKeyDown(KeyCode.Alpha4)) EquipPowerUp(powerUpDirectory["Speed"]);
    }

    private bool IsQueueEmpty()
    {
        return powerUpQueue.Count > 0;
    }

    private bool IsStackEmpty()
    {
        return powerUpStack.Count > 0;
    }

    
    private void EquipPowerUp(GameObject powerUp)
    {
        UnequipPowerUps();
        powerUp.SetActive(true);
        powerUp.transform.parent = tankTop;
        powerUp.transform.localPosition = Vector3.zero;
        powerUp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        
    }     
    
    private void UnequipPowerUps()
    {
        {
            //foreach para recorrer todos los hijos.
            foreach (Transform child in tankTop)
            {
                child.parent = null;
                child.transform.position = new Vector3(Random.Range(0f, 3f), 1f, Random.Range(0f, 3f));
                child.gameObject.SetActive(true);
            }
        }
    }
}
