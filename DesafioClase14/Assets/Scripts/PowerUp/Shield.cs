using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float shieldDuration;
    public GameObject hitEffect;

    private WaitForSeconds shieldDelay;

    private Collider col;

    // Use this for initialization
    void Start()
    {
        transform.localScale = Vector3.zero;
        shieldDelay = new WaitForSeconds(shieldDuration);

        col = GetComponent<Collider>();
        col.enabled = false;

        shieldDuration = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShieldUp();
        }
    }

    public void ShieldUp()
    {
        StartCoroutine(EngageShield());
        Debug.Log ("Shield Up");
    }

    public IEnumerator EngageShield()
    {
        col.enabled = true;

        float inAnimDuration = 0.5f;
        float outAnimDuration = 0.5f;

        while (inAnimDuration > 0f)
        {
            inAnimDuration -= Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(10, 10, 10), 0.1f);
            yield return null;
        }

        yield return shieldDelay;

        while (outAnimDuration > 0f)
        {
            outAnimDuration -= Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 0.1f);
            yield return null;
        }

        transform.localScale = Vector3.zero;
        col.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }

            
    }
}
