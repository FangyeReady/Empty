using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PlayerFire : MonoBehaviour
{
    public Transform midFire;


    //子弹的预制
    GameObject bulletPrefab;

    //攻击间隔
    public float fireInterval = 0.1f;
    float timer = 0f;


    private void Start()
    {
        //加载资源
        bulletPrefab = Resources.Load<GameObject>("Bullet");
    }

    private void Update()
    {
        timer = timer + Time.deltaTime;//Time.deltaTime:上一帧所花的时间
        if ( timer >= fireInterval )
        {
            timer = 0f;
            //实例化: 开火
            Instantiate(bulletPrefab, midFire.position, midFire.rotation);
        }
    }


}
