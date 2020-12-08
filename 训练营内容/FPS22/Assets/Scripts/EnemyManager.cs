using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class EnemyManager : MonoBehaviour
{
    //出生点
    public Transform point1;
    public Transform point2;
    public Transform point3;

    //怪物的预制(模板)  
    public GameObject monsterPrefab1;
    public GameObject monsterPrefab2;
    public GameObject monsterPrefab3;

    //游戏界面
    GameView gameView;

    //第一种monster的生成时间间隔
    float time1 = 8f;
    //第二种monster的生成时间间隔
    float time2 = 12f;
    //第二种monster的生成时间间隔
    float time3 = 20f;

    void Start()
    {
        //赋值
        gameView = GameObject.FindObjectOfType<GameView>();
    }

    /// <summary>
    /// 开始生产敌人
    /// </summary>
    public void CreateEnemies()
    {
        //调用生成
        StartCoroutine(SpwanEnemy1());
        StartCoroutine(SpwanEnemy2());
        StartCoroutine(SpwanEnemy3());
    }


    IEnumerator SpwanEnemy1()
    {
        while (true)
        {
            //得到分数
            if (time1 < 2)
            {
                time1 = 2;
            }
            else if(time1 > 2)
            {
                int score = gameView.GetScore();
                float offsetTime = Mathf.Floor(score / 500f);
                time1 = time1 - offsetTime;
            }
            //生成(实例化)
            GameObject item = Instantiate(monsterPrefab1, point1);
            //设置位置
            item.transform.localPosition = Vector3.zero;
            //设置旋转
            item.transform.localRotation = Quaternion.identity;
            //设置缩放
            item.transform.localScale = Vector3.one;

            //等待N秒
            yield return new WaitForSeconds(time1);
        }
    }

    IEnumerator SpwanEnemy2()
    {
        while (true)
        {
            //得到分数
            if (time2 < 4)
            {
                time2 = 4;
            }
            else if (time2 > 4)
            {
                int score = gameView.GetScore();
                float offsetTime = Mathf.Floor(score / 300f);
                time2 = time2 - offsetTime;
            }
            //生成(实例化)
            GameObject item = Instantiate(monsterPrefab2, point2);
            //设置位置
            item.transform.localPosition = Vector3.zero;
            //设置旋转
            item.transform.localRotation = Quaternion.identity;
            //设置缩放
            item.transform.localScale = Vector3.one;


            //等待N秒
            yield return new WaitForSeconds(time2);

        }
    }


    IEnumerator SpwanEnemy3()
    {
        while (true)
        {
            //等待N秒
            yield return new WaitForSeconds(time3);

            //得到分数
            if (time3 < 6)
            {
                time3 = 6;
            }
            else if (time3 > 6)
            {
                int score = gameView.GetScore();
                float offsetTime = Mathf.Floor(score / 300f);
                time3 = time3 - offsetTime;
            }
            //生成(实例化)
            GameObject item = Instantiate(monsterPrefab3, point3);
            //设置位置
            item.transform.localPosition = Vector3.zero;
            //设置旋转
            item.transform.localRotation = Quaternion.identity;
            //设置缩放
            item.transform.localScale = Vector3.one;

        }
    }



}
