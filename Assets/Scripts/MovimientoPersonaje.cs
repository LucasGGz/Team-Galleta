using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
   private float speed;
    private float speedRotation;
    private float jumpForce;
    private Rigidbody physicBody;
    private bool isJump = false;
    private bool floorDetected = false;
    public Animator animator;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        speed = 6f;
        speedRotation = 300f;
        jumpForce = 6f;
        physicBody = GetComponent<Rigidbody>();
       // Vector3 hi = new Vector3(transform.position.x+2.0f, transform.position.y, transform.position.z);
       animator.SetBool("estaQuieto",true);
       
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento y Rotacion
        float posX = Input.GetAxis("Horizontal");
        float posZ = Input.GetAxis("Vertical");
        float rotationY = Input.GetAxis("Mouse X");

        if(posX !=0 || posZ != 0)
        {
            animator.SetBool("estaCaminando",true);
            animator.SetBool("estaQuieto",false);
        }else{
            animator.SetBool("estaCaminando",false);
            animator.SetBool("estaQuieto",true);
        }


        transform.Translate(new Vector3(posX, 0f, posZ) * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0f, rotationY, 0f) * speedRotation * Time.deltaTime);

         isJump = Input.GetButtonDown("Jump");

        Vector3 floor = transform.TransformDirection(Vector3.down);
        //SALTO

        if (Physics.Raycast(transform.position, floor, 1.03f))
        {
            floorDetected = true;
         //   Debug.Log("Si");
        }
        else
        {
            floorDetected = false;
           // Debug.Log("No");
        }

        if (isJump && floorDetected)
        {
            physicBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); //impulsa al game objet
        }
   
    }


}
