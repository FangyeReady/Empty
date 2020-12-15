using System.Collections.Generic;
using UnityEngine;
using System;
/*九城教育*/
using Random = UnityEngine.Random;
public class BossHealth : MonoBehaviour
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
        //Destroy(this.gameObject, 20f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (Health <= 0)
        {
            return;
        }


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
           //TODO:????
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
        //生成血包
        //随机
        Random.InitState((int)DateTime.Now.Ticks); 
        for (int i = 0; i < 10; i++)
        {
            //得到随机数
            int X = Random.Range(-19, 19);
            Instantiate(hpPrefab, new Vector3(X, transform.position.y, transform.position.z - 55), Quaternion.identity);
        }


        Instantiate(superBuffPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 60), Quaternion.identity);   
    }
}
