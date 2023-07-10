using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoriaCoportamiento : MonoBehaviour
{
    [SerializeField]
    private GameObject premio;
    [SerializeField]
    private GameObject youwintext;
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
            Instantiate(premio, transform.position, transform.rotation);
            Debug.Log("Ganastee AHHHH");
            Destroy(gameObject);
            Destroy(other.gameObject);
            youwintext.SetActive(true); //Activa el texto
        }
    }
}
