using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PlayerHealth : MonoBehaviour
{
    public float Health = 5;

    //死亡特效的预制
    public GameObject dieEffectPrefab;

    //得到网格渲染器
    MeshRenderer msr;

    private void Start()
    {
        msr = GetComponent<MeshRenderer>();

        //更新血量
        UIManager.Instance.UpdateHp(Health);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        //碰到了血包
        if (other.gameObject.CompareTag("Hp"))
        {
            //获取血包数据
            ItemHp hp = other.gameObject.GetComponent<ItemHp>();
            float val = hp.addHp;
            //加血
            Health = Health + val;
            //对最高血量做限制
            if ( Health > GameManager.Instance.MaxHP)
            {
                Health = GameManager.Instance.MaxHP;
            }

            //更新血量
            UIManager.Instance.UpdateHp(Health);
           
            //销毁对象
            Destroy(other.gameObject);
        }

        //碰撞的对象的Tag, 是不是PlayerBullet
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            //扣血
            float damage = other.gameObject.GetComponent<EnemyBullet>().ATK;
            Health = Health - damage;
            //销毁子弹
            Destroy(other.gameObject);

            //调用受伤效果
            StartCoroutine(OnHurt());
        }

        //撞上了Enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Health = Health - 1;
            //调用受伤效果
            StartCoroutine(OnHurt());
        }


        //更新血量
        UIManager.Instance.UpdateHp(Health);


        //如果生命值小于0,触发死亡方法
        if (Health <= 0)
        {
            Death();
        }
    }




    public void Death()
    {
        Health = 0f;

        //更新血量
        UIManager.Instance.UpdateHp(Health);

        //游戏结束
        GameManager.Instance.OnGameEnd();

        //死亡特效
        GameObject dieEff = Instantiate(dieEffectPrefab, transform.position, Quaternion.Euler(-80, 0, 0));
        Destroy(dieEff, 4f);

        //死亡的代码
        Destroy(this.gameObject);
    }


    /// <summary>
    /// 受伤的效果显示
    /// </summary>
    /// <returns></returns>
    IEnumerator OnHurt()
    {
        msr.material.color = Color.cyan;

        yield return new WaitForSeconds(0.15f);

        msr.material.color = Color.clear;
    }

    
}
