using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombas : MonoBehaviour
{
    public Transform objetivo;
    public Transform puntoInicio;

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "Player")
    {
        collision.gameObject.transform.position = puntoInicio.position;
        
    }
}
}
