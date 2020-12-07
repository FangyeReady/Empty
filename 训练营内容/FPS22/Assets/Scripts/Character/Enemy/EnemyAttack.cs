using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class EnemyAttack : MonoBehaviour
{
    //攻击力
    public float Attack = 2f;
    //攻击间隔
    public float attackInterval = 1f;

    //计时器
    float timer = 0f;
    //攻击状态: 是否能攻击
    bool canAttack = false;

    //Player身上的脚本: PlayerHealth
    PlayerHealth playerHealth;

    //自己的生命
    EnemyHealth health;


    private void Start()
    {
        //获取
        health = GetComponent<EnemyHealth>();

        //查找赋值玩家
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            playerHealth = obj.GetComponent<PlayerHealth>();
        }
        else
        {
            playerHealth = null;
        }
    }

    private void Update()
    {
        //如果自己已经死亡,则不应该继续攻击
        if (health.IsDead())
        {
            return;//代码运行到此处则终结
        }

        timer = timer + Time.deltaTime;
        if (canAttack && timer >= attackInterval && playerHealth != null)
        {
            timer = 0f;
            playerHealth.OnHurt(Attack);
        }
    }

    //进入接触
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("进入接触   " + other.gameObject.name);
        if (other.CompareTag("Player"))// other.gameObject.tag == "Player"
        {
            canAttack = true;
        }  
    }


    //离开接触
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canAttack = false;
        }
    }
}
