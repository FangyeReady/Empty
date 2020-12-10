using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//解决二义性
using Random = UnityEngine.Random;
public class EnemySpwaner : MonoBehaviour
{
    //敌机的预制
    GameObject enemyPrefab;
    private void Start()
    {
        enemyPrefab = Resources.Load<GameObject>("Enemy");
        StartCoroutine( SPwanEnemy() );
    }
    IEnumerator SPwanEnemy()
    {
        while (true)
        {
            //初始化随机种子
            Random.InitState((int)DateTime.Now.Ticks);
            //得到每次生成N个敌机
            int count = Random.Range(2, 4);
            //int preX = 0;
            //循环生成
            for (int i = 0; i < count; i++)
            {
                int X = Random.Range(-19, 19);
                //错开值
                //while ( Mathf.Abs(X - preX) <= 10 )
                //{
                //    Debug.Log("123");
                //    X = Random.Range(-19, 19);
                //    yield return new WaitForSeconds(0.2f);
                //}
                //preX = X;

                //生成的时间差
                float waitTime = Random.Range(1f, 2f);
                yield return new WaitForSeconds(waitTime);

                //生成
                Instantiate(enemyPrefab, new Vector3(X, 0, 110), Quaternion.Euler(0, 180, 0));
            }

            //得到每次等待的时间
            int spwanTime = Random.Range(1, 3);
            //等待N秒
            yield return new WaitForSeconds(spwanTime);    
        }
    }
}
