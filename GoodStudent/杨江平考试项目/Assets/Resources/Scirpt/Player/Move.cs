using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    //自己的

    float speed =10;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 40f;
        }
        else
        {
            speed = 10f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward*Time.deltaTime*speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            /*m.transform.Rotate(Vector3.down, Time.deltaTime * speed * 60);*/
        }
        if (Input.GetKey(KeyCode.A))
        {
         //   m.transform.Translate(Vector3.left * Time.deltaTime * speed);
            transform.Rotate(Vector3.down, Time.deltaTime * speed*3);
        }
        if (Input.GetKey(KeyCode.D))
        {
          //  m.transform.Translate(Vector3.right * Time.deltaTime * speed);
            transform.Rotate(Vector3.up, Time.deltaTime * speed * 3);
        }
          
    }
}
