using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;
/*九城教育*/
public class EnemyHealth : MonoBehaviour
{
    //生命值
    public int Health = 1;
    //死亡特效
    GameObject dieEffect;

    //大炸弹食物
    GameObject boomFoodPrefab;

    //生命值食物
    GameObject healthFood;

    private void Start()
    {
        //加载死亡特效到内存
        dieEffect = Resources.Load<GameObject>("EnemyDieEff");

        //加载到内存
        boomFoodPrefab = Resources.Load<GameObject>("BigBoomFood");

        //加载到内存
        healthFood = Resources.Load<GameObject>("HealthFood");
    }

    /// <summary>
    /// 被子弹击中的方法
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //如果被玩家的子弹击中
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            //得到玩家的子弹信息
            BulletController bulletController = other.gameObject.GetComponent<BulletController>();
            //生命值减去玩家子弹的攻击力
            Health -= bulletController.Attack;

            //销毁子弹
            Destroy(other.gameObject);
        }

        //如果触发的是Player
        if (other.gameObject.CompareTag("Player"))
        {
            //生命值固定减1
            Health -= GameManager.Instance.GetHitDamage(); ;
        }


        //如果生命值低于0
        if (Health <= 0)
        {
            //触发死亡方法
            Die();
        }
    }

    //死亡的方法
    private void Die()
    {
        UIManager.Instance.UpdateScore(10);

        //生成特效
        Instantiate(dieEffect, this.transform.position, Quaternion.identity);
        //调用生成食物的代码
        CalcCreateFood();

        //销毁自己
        Destroy(this.gameObject);
    }



    //生成各种各样的food
    private void CalcCreateFood()
    {
        //生成随机种子，对随机数初始化
        Random.InitState((int)DateTime.Now.Ticks);

        //生成随机数
        int val = Random.Range(1, 100);
        
        //生成大炸弹的概率30%
        if (val <= 30)
        {
            //生成炸弹
            Instantiate(boomFoodPrefab, this.transform.position, Quaternion.Euler(90, 0, 0));
        }

        //生成血包的概率30%
        if (val <= 60  && val > 30)
        {
            //生成血包
            Instantiate(healthFood, this.transform.position, Quaternion.Euler(90, 0, 0));
        }

    }
}
