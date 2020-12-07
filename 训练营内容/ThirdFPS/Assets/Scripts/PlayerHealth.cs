using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*九城教育*/
public class PlayerHealth : MonoBehaviour
{
    //玩家生命值
    public int health = 5;
    //音效
    public AudioSource hurtAudio;
    //死亡的音频片段
    public AudioClip deathClip;
    //动画
    public Animator anim;

    //受伤的图片
    public Image hurtImage;
    //是否正在被攻击
    private bool isOnAttack = false;

    //死亡状态
    private bool isDead = false;

    private void Start()
    {
        if (hurtImage == null)
        {
            hurtImage = GameObject.Find("HurtImage").GetComponent<Image>();
        }
    }

    private void Update()
    {
        //如果正在被攻击
        if (isOnAttack)
        {
            //图片颜色设置为红色
            hurtImage.color = new Color(1.0f, 0f, 0f, 0.75f);
        }
        else
        {
            //图片颜色重置
            hurtImage.color = Color.Lerp(hurtImage.color, Color.clear, Time.deltaTime * 5);
        }
        //重置被攻击的状态
        isOnAttack = false;
    }


    //玩家被攻击时调用
    public void OnAttack(int damage)
    {
        //如果挂了就在此处终止代码
        if (isDead)
        {
            //终止
            return;
        }
        isOnAttack = true;
        //玩家生命值减少
        health -= damage;
        hurtAudio.Play();
        //玩家生命值如果小于0
        if (health <= 0)
        {
            //调用死亡方法
            Die();
        }
    }

    //玩家死亡时调用的方法
    private void Die()
    {
        //TODO:角色死亡的代码
        isDead = true;

        hurtAudio.Stop();
        hurtAudio.clip = deathClip;
        hurtAudio.Play();

        anim.SetTrigger("Death");
    }
    //返回死亡状态
    public bool IsDead()
    {
        return isDead;
    }
}
