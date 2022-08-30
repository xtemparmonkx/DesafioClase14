using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] PowerUpManager powerUpManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            other.gameObject.SetActive(false);
            powerUpManager.PowerUpList.Add(other.gameObject);
            //COLA
            powerUpManager.PowerUpQueue.Enqueue(other.gameObject);
            Debug.Log("ELEMENTOS EN LA COLA " + powerUpManager.PowerUpQueue.Count);
            //STACK
            powerUpManager.PowerUpStack.Push(other.gameObject);
            Debug.Log("ELEMENTOS EN LA STACK " + powerUpManager.PowerUpStack.Count);
            //DIC
            if (!powerUpManager.PowerUpDirectory.ContainsKey(other.gameObject.name))
            {
                powerUpManager.PowerUpDirectory.Add(other.gameObject.name, other.gameObject);
                Debug.Log(powerUpManager.PowerUpDirectory[other.gameObject.name]);
            }
            
        }
    }

}
