using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_leg2 : MonoBehaviour
{
    int count = 0;
    float speed = 35;
    GameObject turnback;
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

            if (a > 15f && a < 150f)
            {
                count = 0;
            }

            if (a < 345f && a > 250f)
            {
                count = 1;

            }

/*            if (this.transform.rotation.x > 0.1f)
            {
                count = 0;
            }

            if (this.transform.rotation.x < -0.1f)
            {
                count = 1;
            }*/

        }

        else if(Input.GetKey(KeyCode.S))
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
