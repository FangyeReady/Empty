using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random;

/*九城教育*/
public class EnemySpwaner : MonoBehaviour
{
    //每次生成飞机数量
    public int SpwanCount = 3;

    //每波飞机生成的间隔时间
    public float waitTime = 10f;

    //飞机的预制资源
    private GameObject enemyPrefab;

    private void Start()
    {
        //加载飞机的资源到内存
        enemyPrefab = Resources.Load<GameObject>("Enemy");

        //调用生产方法
        StartCoroutine( Spwan() );
    }



    IEnumerator Spwan()
    {
        while (true)
        {
            //只有当游戏开始的时候,才可以进来生产敌机
            if (GameManager.Instance.IsStartGame() == true)
            {
                //循环生成飞机
                for (int i = 0; i < SpwanCount; i++)
                {
                    //初始化随机数
                    Random.InitState((int)DateTime.Now.Ticks);

                    //x方向的随机数
                    float x = Random.Range(-15, 15);

                    //生成飞机        预制资源                          位置                                     朝向
                    GameObject obj =  Instantiate(enemyPrefab, new Vector3(x, 0, 60f), Quaternion.Euler(0, 180, 0));
                    obj.transform.parent = this.transform;

                    //暂停0.25秒
                    yield return new WaitForSeconds(1f);
                }

                //等待10秒后,继续执行
                yield return new WaitForSeconds(waitTime);
            }

            //防止在游戏未开始时, 造成死循环
            yield return null;
  
        }
    
    }

}
