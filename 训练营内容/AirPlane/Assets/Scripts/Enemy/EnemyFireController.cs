using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class EnemyFireController : MonoBehaviour
{
    //开火的位置
    public Transform midPoint;
    //开火的间隔
    public float fireInterval = 3f;
    //子弹的资源
    GameObject bulletPrefab;

    private void Start()
    {
        //加载子弹的资源到内存
        bulletPrefab = Resources.Load<GameObject>("EnemyBullet");

        //调用开火的方法
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (true)
        {
            //生产出一个子弹
            Instantiate(bulletPrefab, midPoint.position, midPoint.rotation);
            //等待一定间隔继续开火
            yield return new WaitForSeconds(fireInterval);
        }
    
    }


}
