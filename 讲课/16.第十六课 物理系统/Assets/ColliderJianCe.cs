using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class ColliderJianCe : MonoBehaviour
{
    Color _color;

    MeshRenderer mesh;

    private void Awake()
    {
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("进入碰撞~~" + collision.transform.name);


        mesh = collision.transform.GetComponent<MeshRenderer>();
        _color = mesh.material.color;

        mesh.material.color = Random.ColorHSV();
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("碰撞持续~~" + collision.transform.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("退出碰撞~~" + collision.transform.name);

        //mesh.material.color = _color;
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("接触开始~~" + other.transform.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("持续接触~~" + other.transform.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("退出接触~~" + other.transform.name);
    }

}
