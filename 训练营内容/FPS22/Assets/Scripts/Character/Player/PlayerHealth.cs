using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PlayerHealth : MonoBehaviour
{
    //初始血量
    public float Health = 100f;
    //音频控制器
    public AudioSource audioSource;
    //死亡音频
    public AudioClip deathAudio;
    //动画控制器
    public Animator ani;

    //受伤的效果
    HurtEffect hurtEffect;
    //死亡状态
    bool isDeath = false;

    //游戏界面
    GameView gameView;

    private void Start()
    {
        hurtEffect = GameObject.FindObjectOfType<HurtEffect>();

        gameView = GameObject.FindObjectOfType<GameView>();
    }

    /// <summary>
    /// player被攻击
    /// </summary>
    /// <param name="damage"></param>
    public void OnHurt(float damage)
    {
        if (isDeath)
        {
            return;//方法在此终结,下面的代码将不被执行
        }
        //播放受伤音效
        audioSource.Stop();
        audioSource.Play();
        //播放受伤动画
        hurtEffect.PlayEffect();
        //扣血
        Health = Health - damage;
        //如果血量小于等于0,触发死亡逻辑
        if (Health <= 0)
        {
            Health = 0;
            Death();
        }

        //更新血条
        gameView.UpdateBloodUI(Health);
    }

    private void Death()
    {
        isDeath = true;

        //停止播放受伤音效
        audioSource.Stop();
        //设置死亡音频资源
        audioSource.clip = deathAudio;
        //播放
        audioSource.Play();

        //调用死亡动画
        ani.SetTrigger("Death");
    }

    /// <summary>
    /// 返回死亡状态
    /// </summary>
    /// <returns></returns>
    public bool IsDead()
    {
        return isDeath;
    }

    /// <summary>
    /// 死亡动画的事件方法
    /// </summary>
    public void RestartLevel()
    {
        Debug.Log("重新开始游戏~~~!");
    }
}
