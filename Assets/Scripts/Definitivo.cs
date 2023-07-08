using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Definitivo : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public int filas;
    public int columnas;
    public float tiempoEntreEnemigos = 2f; // Tiempo en segundos entre cada instanciación de enemigo
    public float tiempoVidaEnemigo = 5f; // Tiempo en segundos antes de destruir los enemigos

    private Vector3[,] spawnPoints;

    private void Start()
    {
        // Inicializar matriz bidimensional
        spawnPoints = new Vector3[filas, columnas];

        // Calcular la posición y el tamaño total del área de spawn
        float spawnAreaWidth = columnas * enemigoPrefab.transform.localScale.x;
        float spawnAreaHeight = filas * enemigoPrefab.transform.localScale.y;
        Vector3 spawnAreaCenter = transform.position;

        // Llenar la matriz con los puntos de spawn
        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                // Calcular la posición en el mundo de acuerdo a las coordenadas
                Vector3 posicion = new Vector3(columna, 0, fila);

                // Guardar el punto de spawn en la matriz
                spawnPoints[fila, columna] = posicion;
            }
        }

        // Llamar a la función SpawnEnemy cada cierto tiempo
        InvokeRepeating("SpawnEnemy", 0f, tiempoEntreEnemigos);
    }

    private void SpawnEnemy()
    {
        // Escoger una posición de spawn aleatoria
        int filaAleatoria = Random.Range(0, filas);
        int columnaAleatoria = Random.Range(0, columnas);
        Vector3 posicionSpawn = spawnPoints[filaAleatoria, columnaAleatoria];

         // Instanciar el enemigo en la posición aleatoria
         GameObject enemigo = Instantiate(enemigoPrefab, posicionSpawn, Quaternion.identity);

         // Destruir el enemigo después de tiempoVidaEnemigo segundos
         Destroy(enemigo, tiempoVidaEnemigo);
    }
}