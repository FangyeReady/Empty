using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
/*九城教育*/
public class StoneSpwaner : MonoBehaviour
{
    //石头的变量
    GameObject stonePrefab;

    private void Start()
    {
        //加载石头变量到内存中
        stonePrefab = Resources.Load<GameObject>("Stone");

        //开启石头的生成
        StartCoroutine(Spwan());
    }

    IEnumerator Spwan()
    {
        while (true)
        {
            if (GameManager.Instance.IsStartGame() == true)
            {
                //初始化随机数
                Random.InitState((int)DateTime.Now.Ticks);

                //x方向的随机数
                float x = Random.Range(-15, 15);

                //生成飞机        预制资源                          位置                                     朝向
                GameObject obj = Instantiate(stonePrefab, new Vector3(x, 0, 70f), Quaternion.Euler(0, 180, 0));
                obj.transform.parent = this.transform;
                //生成随机间隔时间
                int time = Random.Range(5, 15);
                yield return new WaitForSeconds(time);
            }

            yield return null;
         
        }

    }
}
