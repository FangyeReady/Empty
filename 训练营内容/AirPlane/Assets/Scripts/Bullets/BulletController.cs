using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public int Attack = 1;

    private void Awake()
    {
        //5秒后销毁子弹
        Destroy(this.gameObject,  5f);
    }

    private void Update()
    {
        //移动
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
