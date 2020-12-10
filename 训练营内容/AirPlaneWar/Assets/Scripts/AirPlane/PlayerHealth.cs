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
    }
    

    private void OnTriggerEnter(Collider other)
    {
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
        //如果生命值小于0,触发死亡方法
        if (Health <= 0)
        {
            Death();
        }
    }




    public void Death()
    {
        Health = 0f;

        //死亡的代码
        Destroy(this.gameObject);

        //死亡特效
        GameObject dieEff = Instantiate(dieEffectPrefab, transform.position, Quaternion.Euler(-80, 0, 0));
        Destroy(dieEff, 4f);
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
