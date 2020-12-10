using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/


using Random = UnityEngine.Random;
public class StoneSpwaner : MonoBehaviour
{
    //游戏对象的数组
    GameObject[] stones;
    //浮点数的数组
    float[] waitTimeArray;

    private void Start()
    {
        //初始化
        waitTimeArray = new float[5] { 5, 10, 15, 20, 25 };

        //初始化数组中有五个元素
        stones = new GameObject[5];
        //循环对数组元素赋值
        for (int i = 0; i < stones.Length; i++)
        {
            stones[i] = Resources.Load<GameObject>("Stone_" + (i + 1) );
        }
        //开启生产敌人
        StartCoroutine(SpwanStones());
    }

    IEnumerator SpwanStones()
    {
        while (true)
        {
            Random.InitState((int)DateTime.Now.Ticks);
            //获取一个数组范围内的下标
            int index1 = Random.Range(0, stones.Length - 1);

            GameObject prefab = stones[index1];

            int X = Random.Range(-19, 19);
            Instantiate(prefab, new Vector3(X, 0, 100), Quaternion.Euler(0, 180, 0));

            //随机下标
            int index2 = Random.Range(0, waitTimeArray.Length - 1);
            //获取等待时间
            float waitTime = waitTimeArray[index2];
            //等待
            yield return new WaitForSeconds(waitTime);
        }
    }


}
