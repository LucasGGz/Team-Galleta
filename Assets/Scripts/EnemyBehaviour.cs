using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform objetivo;              // Variable que representa el objetivo que el enemigo debe seguir
    public float rangoDeAtaque = 6f;        // Rango maximo de distancia para atacar al objetivo
    public float velocidadEnemigo = 4f;      // Velocidad a la que se mueve el enemigo
    public Animator animator;

    void Update()
    {
        float distancia = CalcularDistancia();   // Calcula la distancia entre el enemigo y el objetivo

        if (distancia <= rangoDeAtaque)   // Si la distancia esta dentro del rango de ataque
        {
            float deltaX = objetivo.position.x - transform.position.x;    // Calcula el cambio en la posicion X entre el objetivo y el enemigo
            float deltaZ = objetivo.position.z - transform.position.z;    // Calcula el cambio en la posicion Z entre el objetivo y el enemigo

            float pendiente = deltaZ / deltaX;    // Calcula la pendiente de la linea que conecta al enemigo y al objetivo
            float ordenadaOrigen = objetivo.position.z - pendiente * objetivo.position.x;    // Calcula la ordenada al origen de la linea

            float nuevoX = transform.position.x + deltaX * velocidadEnemigo * Time.deltaTime;    // Calcula la nueva posicion X del enemigo con velocidad
            float nuevoZ = pendiente * nuevoX + ordenadaOrigen;    // Calcula la nueva posicion Z del enemigo utilizando la funcion lineal

            transform.position = new Vector3(nuevoX, transform.position.y, nuevoZ);    // Actualiza la posicion del enemigo a la nueva posici�n calculada
            transform.LookAt(objetivo);    // Hace que el enemigo mire hacia el objetivo
            animator.SetBool("estaCaminando",true);
            animator.SetBool("estaBailando",false);
        }else{
            animator.SetBool("estaCaminando",false);
            animator.SetBool("estaBailando",true);
        }
    }

    public float CalcularDistancia()
    {
        float distancia = Mathf.Sqrt(Mathf.Pow(objetivo.position.x - transform.position.x, 2f) +
            Mathf.Pow(objetivo.position.y - transform.position.y, 2f) +
            Mathf.Pow(objetivo.position.z - transform.position.z, 2f));    // Calcula la distancia en lonea recta entre el enemigo y el objetivo

        return distancia;    // Devuelve la distancia calculada
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            objetivo.position = new Vector3(-24.5f,-4.51f,-65.7f);
            Debug.Log("toco");
        }
    }
}
