using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matriz : MonoBehaviour
{
     public GameObject bombas; //Se declara una variable bomba de tipo GameObject.
     public int filas; //Se definen las variables filas.
     public int columnas; //Se definen las variables columnas.
     public float tiempoEntreBombas = 2f; // Tiempo en segundos entre cada instanciación de bomba
     public float tiempoVidaBombas = 5f; // Tiempo en segundos antes de destruir las bombas

     private Vector3[,] spawnPoints; //Se declara una matriz bidimensional de tipo Vector3 llamada "spawnPoints" que almacenará los puntos de spawn.
     private bool[,] spawnOccupied; //Se declara una matriz bidimensional de tipo bool llamada "spawnOccupied" que almacenará información sobre si un punto de spawn está ocupado o no.

     private void Start()
     {
         // Inicializar matriz bidimensional "spawnPoints" con el tamaño especificado por las variables "filas" y "columnas".
         spawnPoints = new Vector3[filas, columnas];

         // Llenar la matriz con los puntos de spawn
         for (int fila = 0; fila < filas; fila++)
         {
             for (int columna = 0; columna < columnas; columna++)
             {
                // Calcular la posición en el mundo de acuerdo a las coordenadas
                float posX = columna * 1f; // Ajusta el espaciado horizontal de los puntos de spawn
                float posZ = fila * 1f; // Ajusta el espaciado vertical de los puntos de spawn
                Vector3 posicion = new Vector3(posX, 0, posZ); //Se crea una posición tridimensional usando los valores de posX y posZ, y se almacena en el objeto "posicion".

                // Guardar el punto de spawn en la matriz
                spawnPoints[fila, columna] = posicion; //"fila" y "columna" son variables que indican la posición del elemento en la matriz.
             }
         }

         // Llamar a la función SpawnEnemy cada cierto tiempo (El tiempo entre cada llamada se especifica en la variable "tiempoEntreBombas").
         InvokeRepeating("SpawnBomba", 0f, tiempoEntreBombas);

         spawnOccupied = new bool[filas,columnas]; //Se inicializa la matriz "spawnOccupied" con el mismo tamaño que la matriz "spawnPoints".
     }

     private void SpawnBomba() // El método "SpawnBomba" se ejecuta cuando se llama desde la función "InvokeRepeating".
     {
         // Escoger una posición de spawn aleatoria
         int filaAleatoria = Random.Range(0, filas);
         int columnaAleatoria = Random.Range(0, columnas);

         while(spawnOccupied[filaAleatoria,columnaAleatoria])//Se comprueba si esta posición ya está ocupada en la matriz "spawnOccupied". Si está ocupado, se generará una nueva posición aleatoria hasta que se encuentre una posición no ocupada.
         {
            filaAleatoria = Random.Range(0, filas);
            columnaAleatoria = Random.Range(0, columnas);
         }
         Vector3 posicionSpawn = spawnPoints[filaAleatoria, columnaAleatoria];

         //Marcar el punto de spawn como ocupado.
         spawnOccupied[filaAleatoria,columnaAleatoria] = true;

          // Instanciar la bomba en la posición aleatoria
          GameObject bomba = Instantiate(bombas, posicionSpawn, Quaternion.identity);

          // Destruir la bomba después de tiempoVidaBombas segundos
          Destroy(bomba, tiempoVidaBombas);
     }
     }
    