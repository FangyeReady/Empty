using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class RigidAddForce : MonoBehaviour
{
    public Rigidbody rid;


    public int Force = 1000;

    private void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rid.AddForce(Vector3.up * 10, ForceMode.Acceleration);
        }



        if (Input.GetKeyDown(KeyCode.A))
        {
            //世界坐标系
            rid.AddForce(Vector3.forward * Force, ForceMode.Force);

            //本地坐标系
            //rid.AddRelativeForce(Vector3.forward * Force, ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            rid.AddForce(Vector3.left * 10, ForceMode.Acceleration);
        }


        if (Input.GetKeyDown(KeyCode.C))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 dir = Vector3.forward;
            if (Physics.Raycast(ray, out hit))
            {
                dir = hit.point;
            }

            rid.AddForce((dir - transform.position).normalized * Force, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rid.AddForce(Vector3.forward * 10, ForceMode.VelocityChange);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            //世界坐标系
            //rid.AddTorque(Vector3.up * 10, ForceMode.Force);


            //本地坐标系
            rid.AddRelativeTorque(Vector3.up * 100, ForceMode.Force);
        }




        Debug.Log("速率:" + rid.velocity);
    }

}
