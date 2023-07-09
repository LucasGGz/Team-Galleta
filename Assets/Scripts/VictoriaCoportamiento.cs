using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoriaCoportamiento : MonoBehaviour
{
    [SerializeField]
    private GameObject premio;
    void Start()
    {
        
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
        }
    }
}
