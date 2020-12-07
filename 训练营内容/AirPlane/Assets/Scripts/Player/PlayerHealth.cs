using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PlayerHealth : MonoBehaviour
{
    //生命值
    [SerializeField] int health = 5;
    public int Health {
        set {
            health = value;

            UIManager.Instance.UpdateHealth(health);
        }

        get {
            return health;
        }
    
    }
    //死亡特效
    GameObject dieEffect;

    //网格渲染组件
    MeshRenderer renderer;

    private void Start()
    {
        //加载死亡特效到内存
        dieEffect = Resources.Load<GameObject>("EnemyDieEff");
        //对网格渲染组件赋值
        renderer = GetComponent<MeshRenderer>();
    }

    /// <summary>
    /// 被子弹击中的方法
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        if (!GameManager.Instance.IsStartGame())
        {
            return;
        }

        //如果被玩家的子弹击中
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            //得到玩家的子弹信息
            BulletController bulletController = other.gameObject.GetComponent<BulletController>();
            //生命值减去玩家子弹的攻击力
            Health -= bulletController.Attack;
            StartCoroutine(OnHurt());
            //销毁子弹
            Destroy(other.gameObject);
        }

        //如果触发的是敌机
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Stone"))
        {
            //生命值固定减1
            Health -= GameManager.Instance.GetHitDamage();
            StartCoroutine(OnHurt());
        }

        //如果触发的是食物：大炸弹
        if (other.gameObject.CompareTag("BigBoomFood"))
        {
            int curCount = GameManager.Instance.GetBoomCount();
            int maxCount = GameManager.Instance.GetMaxBoomCount();

            //如果当前炸弹数量 小于 炸弹数量上限
            if ( curCount  < maxCount )
            {
                //增加炸弹
                GameManager.Instance.BoomCount += 1;
            }
           
            //销毁被触发的对象
            Destroy(other.gameObject);
        }


        //如果触发的是食物: 血包
        if (other.gameObject.CompareTag("HealthFood"))
        {
            //得到最大血量
            int maxHealth = GameManager.Instance.GetMaxHealth();
            //如果当前血量低于最大血量则加血
            if (Health < maxHealth)
            {
                Health += 1;
            }
            //销毁血量包
            Destroy(other.gameObject);
        }


        //如果生命值低于0
        if (Health <= 0)
        {
            //触发死亡方法
            Die();
        }
    }

    //受伤的代码
    IEnumerator OnHurt()
    {
        //设置颜色为红色
        renderer.material.color = Color.red;
        //等待0.25秒
        yield return new WaitForSeconds(0.25f);
        //还原飞机的颜色
        renderer.material.color = Color.white;
    }

    //死亡的方法
    private void Die()
    {
        //生成特效
        Instantiate(dieEffect, this.transform.position, Quaternion.identity);
        GameManager.Instance.SetGameEnd();
        //销毁自己
        Destroy(this.gameObject);
    }

}
