using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMovement : MonoBehaviour
{
    [SerializeField]
    private int plataformType; //Nos sirve para indicar el tipo de plataforma .
    [SerializeField]
    private float speedPlataform1 = 1f; //Velocidad de la plataforma1.
    [SerializeField]
    private float speedPlataform2 = 1f; //Velocidad de plataforma2.
    [SerializeField]
    private float speedPlataform3 = 1f; //Velocidad de plataforma3.
    [SerializeField]
    private float speedPlataform4 = 1f; //Velocidad de plataforma3.
    [SerializeField]
    private float speedPlataform5 = 1f; //Velocidad de plataforma3.

    // Update is called once per frame
    void Update()
    {
       MovePlataform(); //Invocamos al metodo que hara que las plataformas se muevan.
    }

     public void MovePlataform()
    {
         switch(plataformType)
        {
            case 1:
            {
             if(transform.position.x < -24.32f || transform.position.x > -10.36f)
             {
                speedPlataform1 *= -1;
             }
            transform.Translate(speedPlataform1*Time.deltaTime,0,0); //Hara que la plataforma1 se mueva de izquierda a derecha en el eje "x".
            break;
            }
            case 2:
            {
             if(transform.position.x < -52.52f || transform.position.x > -33.28442f)
             {
                speedPlataform2 *= -1;
             }
            transform.Translate(speedPlataform2*Time.deltaTime,0,0); //Hara que la plataforma2 se mueva de izquierda a derecha en el eje "x".
            break;
            }
            case 3:
            {
             if(transform.position.y > -1.9f || transform.position.y < -6.46f)
             {
                speedPlataform3 *= -1;
             }
            transform.Translate(0,speedPlataform3*Time.deltaTime,speedPlataform3*Time.deltaTime); //Hara que la plataforma3 se mueva de de arriba abajo en el eje "y".
            break;
            }
            case 4:
            {
             if(transform.position.z > 18.25f || transform.position.z < 0.9f)
             {
                speedPlataform4 *= -1;
             }
            transform.Translate(0,0,speedPlataform4*Time.deltaTime); //Hara que la plataforma3 se mueva de de arriba abajo en el eje "y".
            break;
            }
             case 5:
            {
             if(transform.position.x > 0.07f || transform.position.x < -11.78f)
             {
                speedPlataform5 *= -1;
             }
            transform.Translate(speedPlataform5*Time.deltaTime,0,0); //Hara que la plataforma3 se mueva de de arriba abajo en el eje "y".
            break;
            }
            
        }
    }

      private void OnCollisionEnter(Collision collision) //Permite que cuando el jugador haga contacto con la plataforma se transforme en hijo y se mueva junto a esta.
       {
          if(collision.gameObject.CompareTag("Player"))
          {
            collision.gameObject.transform.SetParent(transform);
          }
          }
         
        private void OnCollisionExit(Collision collision) //Cuando el jugador deje de tocar la plataforma deja el emparentamiento.  
       {
            if(collision.gameObject.CompareTag("Player"))
          {
            collision.gameObject.transform.SetParent(null);
          }
       }

}
