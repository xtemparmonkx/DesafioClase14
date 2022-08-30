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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (IsQueueEmpty())
            {
                GameObject powerUp = powerUpQueue.Dequeue() as GameObject;
                EquipPowerUp(powerUp);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (IsStackEmpty())
            {
                GameObject powerUp = powerUpStack.Pop() as GameObject;
                EquipPowerUp(powerUp);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipPowerUp(powerUpDirectory["Shield"]);
        if (Input.GetKeyDown(KeyCode.Alpha4)) EquipPowerUp(powerUpDirectory["Health"]);
        if (Input.GetKeyDown(KeyCode.Alpha5)) EquipPowerUp(powerUpDirectory["Bullet"]);
        if (Input.GetKeyDown(KeyCode.Alpha6)) EquipPowerUp(powerUpDirectory["Speed"]);
    }

    private bool IsQueueEmpty()
    {
        return powerUpQueue.Count > 0;
    }

    private bool IsStackEmpty()
    {
        return powerUpStack.Count > 0;
    }

    /*
    void DiseableAllPowerUps()
    {

        for (int i = 0; i < powerUps.Length; i++)
        {
            powerUps[i].SetActive(false); // 0 -> Weapon A  1->WB / 2 -> WC
        }
    }
    */

    private void EquipPowerUp(GameObject powerUp)
    {
        UnequipPowerUps();
        powerUp.SetActive(true);
        powerUp.transform.parent = tankTop;
        powerUp.transform.localPosition = Vector3.zero;
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
