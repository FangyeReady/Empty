using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//引入导航系统的命名空间
/*九城教育*/
public class EnemyMove : MonoBehaviour
{
    //导航代理
    NavMeshAgent agent;
    //玩家
    Transform player;

    //自己的Health
    EnemyHealth health;


    Animator ani;
    bool canWalking = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        ani = GetComponent<Animator>();
    }

    private void Start()
    {
        //查找赋值玩家
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            player = obj.transform;
        }
        else
        {
            player = null;
        }

        Invoke("GoWalking", 1f);
    }

    private void Update()
    {
      
        bool isDead = health.IsDead();
        //如果玩家不存在, 或者, 自己已经死亡
        if (player == null  ||  isDead || !canWalking)
        {
            return;
        }

        //不断的更新导航目标位置
        agent.SetDestination(player.position);
    }


    public void GoWalking()
    {
        canWalking = true;
        ani.SetBool("IsWalking", true);
    }

}
