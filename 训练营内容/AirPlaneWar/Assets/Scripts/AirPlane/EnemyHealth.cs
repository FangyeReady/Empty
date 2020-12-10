using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class EnemyHealth : MonoBehaviour
{
    //生命值
    public float Health = 10f;

    //死亡特效的预制
    public GameObject dieEffectPrefab;


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

        if (Health <= 0)
        {
            //死亡的代码
            Destroy(this.gameObject);

            //死亡特效
            GameObject dieEff = Instantiate(dieEffectPrefab, transform.position, Quaternion.Euler(-80, 0, 0));
            Destroy(dieEff, 4f);
        }
    }


}
