using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPremios : MonoBehaviour
{

    public int type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 0)
        {
            transform.Rotate(0f, 0f, 90f * Time.deltaTime);
        }
        if (type == 1)
        {
            transform.Rotate(0f, 90f * Time.deltaTime, 0f);
        }
        if (type ==2)
        {
            transform.Rotate(0, 90 * Time.deltaTime, 0); //hacemos que gire
        }
        
    }
}
