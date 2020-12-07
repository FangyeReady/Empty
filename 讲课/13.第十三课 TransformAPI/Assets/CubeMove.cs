using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class CubeMove : MonoBehaviour
{
    private void Update()
    {
        //默认为本地坐标系方向移动
        //transform.Translate(Vector3.forward * Time.deltaTime * 5);


        //指定世界坐标系移动
        //transform.Translate(Vector3.forward * Time.deltaTime * 5, Space.World);
    }
}
