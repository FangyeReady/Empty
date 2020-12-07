using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
/*九城教育*/
public class PlayerMovement : MonoBehaviour
{

    public Transform targetPos;


    public NavMeshAgent agent;

    private void Start()
    {
        // agent.SetDestination(targetPos.position);


       // agent.areaMask = ~(1 << 3 | 1) ;
    }



    private void Update()
    {
        //用摄像机创建射线, 以及射线检测
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(_ray.origin, _ray.direction * 100, UnityEngine.Color.green, 3f);


           //Debug.DrawLine(_ray.origin, Point, UnityEngine.Color.green, 3f);

            RaycastHit hitInfo;
            bool isHit = Physics.Raycast(_ray, out hitInfo, 100f, LayerMask.GetMask("Default"));
            if (isHit)
            {
                Debug.Log("碰撞点:" + hitInfo.point + "   碰撞的对象是: " + hitInfo.transform.name);

                agent.SetDestination(hitInfo.point);

            }
        }
    }

}
