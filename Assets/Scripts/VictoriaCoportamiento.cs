using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoriaCoportamiento : MonoBehaviour
{
    [SerializeField]
    private GameObject premio; //objeto a intanciar
    [SerializeField]
    private GameObject youwintext; //texto que mostraremos
    void Start()
    {
        youwintext.SetActive(false); //hace que el texto no se vea al inicio
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Premio") == true)
        {
            Instantiate(premio, transform.position, transform.rotation); //instancia el premio
            Debug.Log("Ganastee AHHHH");
            Destroy(gameObject); // destruye este objeto
            Destroy(other.gameObject); //destruye el premio que lleva el jugador
            youwintext.SetActive(true); //Activa el texto
        }
    }
}
