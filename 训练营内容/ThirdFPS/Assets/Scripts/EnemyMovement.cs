using System.Collections.Generic;
using UnityEngine;

//导航系统的命名空间
using UnityEngine.AI;

/*九城教育*/
public class EnemyMovement : MonoBehaviour
{
    //导航系统
    public NavMeshAgent agent;

    //导航的目标
    private Transform target;

    //血量
    private EnemyHealth health;

    //动画
    private Animator anim;

    //会被Unity自动调用一次
    private void Awake()
    {
        //通过tag找到Player
        target = GameObject.FindGameObjectWithTag("Player").transform;

        health = GetComponent<EnemyHealth>();

        anim = GetComponent<Animator>();
    }

    //会被Unity自动调用一次
    private void Start()
    {
        //设置移动动画
        anim.SetBool("IsWalking", true);
    }

    private void Update()
    {
        //如果找到了Player, 同时自己不在死亡状态
        if (target != null  && !health.IsDead())
        {
            //设置导航地点为Player当前地点
            agent.SetDestination( target.position );
        }
    }


}
