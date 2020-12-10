using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Stone : MonoBehaviour
{
    //速度
    public float speed = 5f;

    private void Awake()
    {
        //销毁
        Destroy(this.gameObject, 30f);
    }

    private void Update()
    {
        //朝前移动
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        //撞上了Player
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().Death();
        }
        //撞上了玩家子弹
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
