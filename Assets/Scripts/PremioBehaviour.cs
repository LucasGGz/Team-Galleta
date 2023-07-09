using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremioBehaviour : MonoBehaviour
{
    private Transform playerPos;
    private float dist;
    private float angulo = 0;
    [SerializeField]
    private int premioType;


    void Start()
    {
        dist = 1f;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

         transform.Rotate(0, 100 * Time.deltaTime, 0); //hacemos que gire

       
            float pos_x = playerPos.transform.position.x + Mathf.Cos(angulo * Mathf.Deg2Rad) * dist; //esto va a situar al premio a lado de el player
            float pos_y = playerPos.transform.position.y+1f;
            float pos_z = playerPos.transform.position.z + Mathf.Sin(angulo * Mathf.Deg2Rad) * dist;
            transform.position = new Vector3(pos_x, pos_y, pos_z);
        
    }
   /* private void OnTriggerEnter(Collider other)
    {


       
            if (other.CompareTag("PremioUlt") == true)
            {
                Destroy(other.gameObject);
            }//esto va a destruir el premio
        
    }*/
}



    

