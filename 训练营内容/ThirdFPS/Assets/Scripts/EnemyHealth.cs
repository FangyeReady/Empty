using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*九城教育*/
public class EnemyHealth : MonoBehaviour
{
    //生命值
    public int Health = 10;
    //受攻击的特效
    public ParticleSystem effect;
    //死亡特效
    public ParticleSystem deathEff;

    //动画组件的使用
    public Animator anim;
    //受伤音效
    public AudioSource hurtAudio;

    //死亡的音频片段
    public AudioClip deathClip;

    //下沉速度
    public float sinkingSpeed = 2f;

    //声明一个变量, 表示死亡状态
    private bool isDead = false;

    //开始下沉状态控制
    private bool isSinking = false;

    //被攻击的方法
    public void OnAttack(int damage, Vector3 hitPoint)
    {
        //如果死亡为真, 则跳过
        if (isDead == true)
        {
            return;
        }

        //当前生命值减去攻击力
        this.Health -= damage;

        GetComponentInChildren<LookAtCamera>().SetImageValue(this.Health / 10f);

        //播放受伤音效
        hurtAudio.Play();

        //播放特效
        effect.Stop();
        effect.transform.position = hitPoint;
        effect.Play();

        //生命值小于等于0时,触发死亡方法
        if (Health <= 0)
        {
            //死亡方法的调用和实现
            Die();
        }
    }

    //死亡方法
    public void Die()
    {
        //角色死亡为真
        isDead = true;

        //设置音频片段
        hurtAudio.Stop();
        hurtAudio.clip = deathClip;
        hurtAudio.Play();

        //禁用导航系统
        GetComponent<NavMeshAgent>().enabled = false;

        //触发死亡动画
        anim.SetTrigger("death");
    }

    //返回死亡状态
    public bool IsDead()
    {
        return isDead;
    }


    //死亡动画的方法, 会被死亡动画自动调用
    private void StartSinking()
    {
        //设置下沉状态为真
        isSinking = true;

        //移动后2秒钟, 消失
        Destroy(this.gameObject, 2f);

        //播放死亡特效
        deathEff.Play();

    }

    private void Update()
    {
        if (isSinking == true)
        {
            //角色朝-Y方向缓慢移动
            transform.Translate(Vector3.down * sinkingSpeed * Time.deltaTime);
        }
    }

}
