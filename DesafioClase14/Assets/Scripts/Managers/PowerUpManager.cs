using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class PowerUpManager : MonoBehaviour
{
    [SerializeField] GameObject[] powerUps;

    [SerializeField] Transform tankTop;

    [SerializeField] List<GameObject> powerUpsList;

    public List<GameObject> PowerUpsList { get => powerUpsList; set => powerUpsList = value; }
    // Start is called before the first frame update
    void Start()
    {
        powerUps[0].SetActive(true);
        powerUps[0].transform.parent = tankTop;
        powerUps[0].transform.position = Vector3.zero;
    }

    void DiseableAllPowerUps()
    {

        for (int i = 0; i < powerUps.Length; i++)
        {
            powerUps[i].SetActive(false); // 0 -> Weapon A  1->WB / 2 -> WC
        }
    }

    private void HavePowerUp(GameObject powerUp)
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
                //child.transform.position = new Vector3(Random.Range(0f, 3f), 1f, Random.Range(0f, 3f));
                child.transform.position = new Vector3(Random.Range(0f, 3f), 1f, Random.Range(0f, 3f));
                child.gameObject.SetActive(true);
            }
        }
    }
}
