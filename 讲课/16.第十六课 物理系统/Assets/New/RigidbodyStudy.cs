using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class RigidbodyStudy : MonoBehaviour
{
    Rigidbody rid;
    void Start()
    {
        rid = GetComponent<Rigidbody>();

        //瞬移
        rid.MovePosition(transform.position + transform.forward * 2f);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            rid.velocity = Vector3.forward;     //给对象一个速率, 会考虑摩擦因素
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            rid.angularVelocity = Vector3.up;   //给对象一个角速度, 会考虑摩擦因素
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            //rid.useGravity = false;
            rid.isKinematic = true;//????
        }

        //向前匀速运动
        if (Input.GetKey(KeyCode.W))
        {
           
            rid.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * 2f);//transform.forward * 2
        }
        //向后匀速运动
        if (Input.GetKey(KeyCode.S))
        {
            
            rid.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * 2f);
        }


        //转向
        if (Input.GetKey(KeyCode.A))
        {
            rid.MoveRotation(   transform.rotation * Quaternion.Euler(0, -Time.fixedDeltaTime * 60, 0)  );
        }

        if (Input.GetKey(KeyCode.D))
        {
            rid.MoveRotation(   transform.rotation * Quaternion.Euler(0, Time.fixedDeltaTime * 60, 0)   );
        }


        //
        //添加力

        //持续的方向力
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rid.AddForce(Vector3.forward * 50f, ForceMode.Force);
        }
        //加速度
        if (Input.GetKey(KeyCode.J))
        {
            rid.AddForce(Vector3.forward * 2f, ForceMode.Acceleration);
        }

        //瞬间力 : 爆发力
        if (Input.GetKeyDown(KeyCode.I))
        {
            rid.AddForce(Vector3.forward * 200f, ForceMode.Impulse);
        }
        //直接修改速率
        if (Input.GetKeyDown(KeyCode.C))
        {
            rid.AddForce(Vector3.forward * 2f, ForceMode.VelocityChange);
        }

        //Debug.Log("速率 : " + rid.velocity);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("碰撞进入~~!" + collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("碰撞保持~~!" + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("碰撞结束~~!" + collision.gameObject.name);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("进入接触~~~~~" + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("保持接触~~~~~" + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("离开接触~~~~~" + other.gameObject.name);
    }

}
