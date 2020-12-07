using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class RigidControllUpdate : MonoBehaviour
{
    Rigidbody rid;


    public Transform target;

    private void Awake()
    {
        rid = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        Debug.Log("是否在休眠:  " + rid.IsSleeping());


        if (rid.IsSleeping())
        {
            rid.WakeUp();
        }

        //transform.Translate()


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rid.MovePosition(transform.position + new Vector3(x, 0, z) * 10 * Time.deltaTime);


        Quaternion lookTarget = Quaternion.LookRotation(target.position - transform.position);
        Quaternion targetRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime);
        rid.MoveRotation(targetRotation);
    }
}
