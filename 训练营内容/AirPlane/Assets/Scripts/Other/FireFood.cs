using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class FireFood : MonoBehaviour
{
    //移动速度
    public float speed = 10f;

    private void Update()
    {
        //移动
        transform.Translate(Vector3.back * Time.deltaTime * speed , Space.World);
    }
}
