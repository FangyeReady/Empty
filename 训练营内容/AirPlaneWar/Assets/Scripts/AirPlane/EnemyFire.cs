using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class EnemyFire : MonoBehaviour
{
    //子弹
    public GameObject bulletPrefab;
    //开火点
    public Transform midFire;
    //开火频率
    public float fireInterval = 2f;
    //计时器
    float timer = 0f;

    private void Update()
    {
        timer = timer + Time.deltaTime;//Time.deltaTime:上一帧所花的时间
        if (timer >= fireInterval)
        {
            timer = 0f;
            //实例化: 开火
            Instantiate(bulletPrefab, midFire.position, midFire.rotation);
        }
    }

}
