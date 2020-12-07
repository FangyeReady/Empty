using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class EnemyAttack : MonoBehaviour
{
    //每次攻击的伤害
    public int damage = 1;
    //攻击间隔
    public float attackInterval = 0.5f;
    //攻击计时
    private float timer = 0f;
    //判断是否可以攻击
    private bool IsInRange = false;

    //玩家生命值
    private PlayerHealth playerHealth;


    private void Start()
    {
        //获得PlayerHealth
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        //计时器增加
        timer += Time.deltaTime;
        //如果可以攻击, 同时满足攻击间隔时间
        if (IsInRange && timer >= attackInterval)
        {
            //重置攻击计时
            timer = 0f;
            //攻击 playerHealth掉血
            playerHealth.OnAttack(damage);
            Debug.Log("开始攻击~~~");
        }
    }


    //开始触发时调用一次
    private void OnTriggerEnter(Collider other)
    {
        //如果触发的是Player
        if (other.gameObject.CompareTag("Player"))
        {
            //TODO:触发攻击
            IsInRange = true;
        }
    }


    //离开:停止触发时调用一次
    private void OnTriggerExit(Collider other)
    {
        //如果离开接触的是Player
        if (other.gameObject.CompareTag("Player"))
        {
            //TODO:停止攻击
            IsInRange = false;
        }
    }


}
