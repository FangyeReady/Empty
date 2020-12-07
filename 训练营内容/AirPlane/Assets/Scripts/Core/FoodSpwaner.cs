using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Collections;
/*九城教育*/
public class FoodSpwaner : MonoBehaviour
{
    //声明一个变量用于存储fireFood资源
    GameObject fireFoodPrefab;
    private void Start()
    {
        //将fireFood资源存储到内存中
        fireFoodPrefab = Resources.Load<GameObject>("FireFood");

        //调用fireFood的生成代码
        StartCoroutine(CreateFireFood());
    }

    //创造火力开枪
    IEnumerator CreateFireFood()
    {
        //开启一个循环
        while (true)
        {

            if (GameManager.Instance.IsStartGame() == true)
            {
                //初始化随机数
                Random.InitState((int)DateTime.Now.Ticks);
                //随机生成一个位置
                int x = Random.Range(-15, 15);
                //生成fireFood
                GameObject obj = Instantiate(fireFoodPrefab, new Vector3(x, 0, 70f), Quaternion.Euler(90, 0, 0));
                obj.transform.parent = this.transform;
                //得到随机等待时间
                int waitTime = Random.Range(10, 30);
                //等待N秒
                yield return new WaitForSeconds(waitTime);
            }

            yield return null;
        }
    
    }


}
