using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_leg1 : MonoBehaviour
{
    int count=1;
    GameObject turnback;
    float speed = 35f;
   // float rangespeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
      
    }
    private void FixedUpdate()
    {
        turnback = GameObject.FindWithTag("Lowerbody");
        float a = this.transform.localEulerAngles.x;




        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 50f;
        }
        else
        {
            speed = 35f;
        }

        if (Input.GetKey(KeyCode.W))
        {

        
            if (count == 1)
            {
                this.transform.Rotate(Vector3.right, Time.deltaTime * speed);
               
            }
            else
            {
                this.transform.Rotate(Vector3.left, Time.deltaTime * speed);
            }

            if ( a> 15f && a< 150f)
            {
                 count = 0;
            }


            if ( a< 345f && a>250f)
            {
                count = 1;

            }
        }
        else if (Input.GetKey(KeyCode.S))
        {


            if (count == 1)
            {
                this.transform.Rotate(Vector3.right, Time.deltaTime * speed);
            }
            else
            {
                this.transform.Rotate(Vector3.left, Time.deltaTime * speed);
            }

            if (a > 15f && a < 150f)
            {
                count = 0;
            }

            if (a < 345f && a > 250f)
            {
                count = 1;

            }
        }
        else
        {
            this.transform.rotation = turnback.transform.rotation;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
