using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremioBehaviour : MonoBehaviour
{
    private Transform playerPos; //variable tipo transform
    private float dist; // distancia
    private float angulo = 0; //angulo que determinara la posición del premio alrededor del jugador.

    void Start()
    {
        //inicializamos la distancia que se situara el premio del player, y obtenemos el componente transform del player
        dist = 1f; 
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {       //esto va a situar al premio a lado de el player
            //Se calculan las nuevas coods con las funciones trigononometricas, math cos y sin toman el angulo actual en radianes
            //que se multiplica por la distancia, de esta manera se obtiene una nueva posicion ya sea en x o z que esta desplazada del jugador
        float pos_x = playerPos.transform.position.x + Mathf.Cos(angulo * Mathf.Deg2Rad) * dist;
        float pos_y = playerPos.transform.position.y + 1f; //se le suma una unidad para acomodar la posicion
        float pos_z = playerPos.transform.position.z + Mathf.Sin(angulo * Mathf.Deg2Rad) * dist;
        transform.position = new Vector3(pos_x, pos_y, pos_z); //se setea la nueva pos del premio con las coords calculadas, alrdedor del jugador

    }
}



    

