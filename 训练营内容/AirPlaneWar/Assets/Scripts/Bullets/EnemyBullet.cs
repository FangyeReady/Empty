using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class EnemyBullet : MonoBehaviour
{
    //速度
    public float speed = 100f;

    //攻击力
    public float ATK = 2f;

    private void Awake()
    {
        //五秒之后销毁子弹
        Destroy(this.gameObject, 5f);
    }

    private void Update()
    {
        //朝前移动
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
