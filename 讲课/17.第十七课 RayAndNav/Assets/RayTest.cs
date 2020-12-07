using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class RayTest : MonoBehaviour
{
    private void Update()
    {
        //直接New一个射线
        if (Input.GetKeyDown(KeyCode.A))
        {
            Ray _ray = new Ray(transform.position, Vector3.forward * 100);

            Debug.DrawLine(_ray.origin, _ray.direction,  Color.green, 3f);
        }


        //用摄像机创建射线, 以及射线检测
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Debug.DrawLine(_ray.origin, _ray.direction, Color.green, 3f);
            //Debug.DrawRay(_ray.origin, _ray.origin + _ray.direction, Color.green, 3f);


            RaycastHit hitInfo;
            bool isHit = Physics.Raycast(_ray, out hitInfo, 100f, LayerMask.GetMask("UI"));
            if (isHit)
            {
                Debug.Log("碰撞点:" + hitInfo.point + "   碰撞的对象是: " + hitInfo.transform.name);

                Debug.DrawLine(_ray.origin, hitInfo.point, Color.green, 3f);
            }
        }



      

    }
}
