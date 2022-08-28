using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoInferior : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] float velocidadGiro;

    float hMove, vMove;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        
        vMove = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;

        hMove = Input.GetAxis("Horizontal") * velocidad * velocidadGiro * Time.deltaTime;

        transform.Rotate(0, hMove, 0);
        transform.Translate(0, 0, vMove);
    }
}
