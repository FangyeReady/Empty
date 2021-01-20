using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PropertiesTest : MonoBehaviour
{
    Rigidbody rid;
    private void Awake() {
        rid = GetComponent<Rigidbody>();
    }

    private void Start() {
        //向指定位置移动
        // rid.MovePosition( transform.position + transform.forward  * 2f);////transform.forward * 2
    }


    private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.T))
        {
            rid.velocity = Vector3.forward * 10; //直接修改速率, 当启用重力时,需要考虑摩擦因素
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            rid.drag = 1;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            rid.angularVelocity = Vector3.up * 10f;//修改旋转速率,当启用重力时,需要考虑摩擦因素
        }
         if (Input.GetKeyUp(KeyCode.B))
        {
            rid.angularDrag = 1;
        }

       //向指定位置移动
       if (Input.GetKey(KeyCode.W))
       {
           rid.MovePosition( transform.position + transform.forward * Time.fixedDeltaTime * 2f);////transform.forward * 2
       }

       
        if (Input.GetKey(KeyCode.S))
       {
           rid.MovePosition( transform.position - transform.forward * Time.fixedDeltaTime * 2f);
       }


       //转向
       if (Input.GetKey(KeyCode.A))
       {
           rid.MoveRotation(  transform.rotation * Quaternion.Euler(0, -Time.fixedDeltaTime * 60, 0) );
       }

        if (Input.GetKey(KeyCode.D))
       {
           rid.MoveRotation(  transform.rotation * Quaternion.Euler(0, Time.fixedDeltaTime * 60, 0) );
       }


        Debug.Log("是否在休眠:  " + rid.IsSleeping());
        if (rid.IsSleeping())
        {
            rid.WakeUp();//唤醒刚体
        }

        //添加力
        //持续力
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rid.AddForce(Vector3.forward * 50f, ForceMode.Force);
        }
        //加速度
        if (Input.GetKey(KeyCode.V))
        {
            rid.AddForce(Vector3.forward * 2f, ForceMode.Acceleration);
        }

        //瞬间力
        if (Input.GetKeyDown(KeyCode.I))
        {
            rid.AddForce(Vector3.forward * 20f, ForceMode.Impulse);
        }
        //直接修改速率
         if (Input.GetKeyDown(KeyCode.C))
        {
            rid.AddForce(Vector3.forward * 2f, ForceMode.VelocityChange);
        }

        Debug.Log("速率: " + rid.velocity);
    }
}
