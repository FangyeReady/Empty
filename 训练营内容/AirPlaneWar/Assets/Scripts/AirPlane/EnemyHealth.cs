﻿using System;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/


using Random = UnityEngine.Random;
public class EnemyHealth : MonoBehaviour
{
    //生命值
    public float Health = 10f;

    //分数
    public float score = 10f;

    //死亡特效的预制
    public GameObject dieEffectPrefab;

    //血包的预制
    public GameObject hpPrefab;
    //超级子弹的预制
    public GameObject superBuffPrefab;


    private void Awake()
    {
        Destroy(this.gameObject, 20f);
    }


    private void OnTriggerEnter(Collider other)
    {
        //碰撞的对象的Tag, 是不是PlayerBullet
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            //扣血
            float damage = other.gameObject.GetComponent<Bullet>().ATK;
            Health = Health - damage;

            //销毁子弹
            Destroy(other.gameObject);
        }
        //撞上了Player
        if (other.gameObject.CompareTag("Player"))
        {
            Health = 0;
        }
        //当血量小于等于0时
        if (Health <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        //更新分数
        UIManager.Instance.UpdateScore(score);

        //死亡特效
        GameObject dieEff = Instantiate(dieEffectPrefab, transform.position, Quaternion.Euler(-80, 0, 0));
        Destroy(dieEff, 4f);
        //生成道具
        CreateItems();
        //死亡的代码
        Destroy(this.gameObject);
    }

    void CreateItems()
    {
        //随机
        Random.InitState((int)DateTime.Now.Ticks);

        //得到随机数
        int temp = Random.Range(1, 100);
        //生成血包
        if (temp <= 50)
        {
            Instantiate(hpPrefab, transform.position, Quaternion.identity);
        }
        else if (temp > 50 && temp <= 100)
        {
            Instantiate(superBuffPrefab, transform.position, Quaternion.identity);
        }
    }


}
