using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*九城教育*/
public class EnemyHealth : MonoBehaviour
{
    //怪物的血量
    public float Health = 10;
    //下沉速度
    public float sinkingSpeed = 3;
    //受攻击的特效
    public ParticleSystem hitParticle;
    //死亡的特效
    public ParticleSystem deathParticle;
    //播放音频的控制器
    public AudioSource audioSource;
    //死亡音频
    public AudioClip deathAudio;


    //动画控制器
    Animator ani;

    //碰撞体
    CapsuleCollider collider;
   

    //死亡状态
    bool isDeath = false;

    //下沉状态
    bool isSinking = false;

    private void Start()
    {
        ani = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider>();
    }
    private void Update()
    {
        if (isSinking)
        {
            transform.Translate(Vector3.down * sinkingSpeed * Time.deltaTime);
        }
    }


    /// <summary>
    /// 受攻击,掉血的代码
    /// </summary>
    /// <param name="damage"></param>
    public void OnHurt(float damage, Vector3 pos)
    {
        if (isDeath)
        {
            return;//方法在此终结,下面的代码将不被执行
        }


        //设置受击位置
        hitParticle.transform.position = pos;

        hitParticle.Stop();
        hitParticle.Play();

        //播放音频
        audioSource.Stop();
        audioSource.Play();


        Health = Health - damage;

        if ( Health <= 0 )
        {
            Death();
        }
    }
    public void Death()
    {
        //设置死亡状态
        isDeath = true;

        //停止播放受伤音效
        audioSource.Stop();
        //设置死亡音频资源
        audioSource.clip = deathAudio;
        //播放
        audioSource.Play();

        //触发死亡动画
        ani.SetTrigger("Death");
        //禁用导航
        GetComponent<NavMeshAgent>().enabled = false;

        //使得不可碰撞
        collider.isTrigger = true;

        //修改Layer
        gameObject.layer = LayerMask.GetMask("Default");


        //销毁自身
        Destroy(this.gameObject, 5f);
    }

    /// <summary>
    /// 角色开始下沉
    /// </summary>
    public void StartSinking()
    {
        isSinking = true;

        //播放死亡特效
        deathParticle.Play();
    }

    /// <summary>
    /// 返回死亡状态
    /// </summary>
    /// <returns></returns>
    public bool IsDead()
    {
        return isDeath;
    }

}
