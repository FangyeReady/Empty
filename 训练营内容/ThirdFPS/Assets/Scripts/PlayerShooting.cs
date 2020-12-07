using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PlayerShooting : MonoBehaviour
{
    //枪
    public Transform gunPos;

    //枪的线段
    public LineRenderer line;

    //枪的特效
    public ParticleSystem fireEffect;

    //开枪音效
    public AudioSource audioSource;

    //枪的灯光效果
    public Light[] lights;

    //开枪间隔
    public float fireInterval = 0.3f;
    float timer = 0.0f;

    //特效持续时间占总开火间隔的比例
    public float effTime = 0.3f;

    //每发子弹造成的伤害
    public int damage;

    //开枪的射线
    Ray ray;

    //射线命中后的碰撞信息
    RaycastHit hitInfo;

    //玩家生命值
    PlayerHealth health;
  

    private void Awake()
    {
        ray = new Ray();
        health = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        //如果玩家死亡,则不继续下面的攻击代码
        if (health.IsDead())
        {
            return;
        }

        //不断增加timer
        timer += Time.deltaTime;
        //调用开枪的方法
        if (Input.GetButton("Fire1") && timer >= fireInterval)
        {
            timer = 0f;
            Shoot();
        }


        if (timer >= fireInterval * effTime)
        {
            HideEffects();
        }
    }



    //开枪的方法
    void Shoot()
    {
        //重置特效
        fireEffect.Stop();
        //播放特效
        fireEffect.Play();

        //声效
        audioSource.Play();

        //开枪的灯光特效
        lights[0].enabled = true;
        lights[1].enabled = true;

        //开枪的线段
        line.enabled = true;
        //设置线段的起始位置
        line.SetPosition(0, gunPos.position);


        //射线的初始位置
        ray.origin = gunPos.position;
        //射线的方向
        ray.direction = gunPos.forward;

        //从枪口发射一根朝前的射线
        bool isHit = Physics.Raycast(ray, out hitInfo,  100f,  LayerMask.GetMask("Enemy"));

        if (isHit)
        {
            //对敌人造成伤害  
            EnemyHealth enemyHealth = hitInfo.collider.GetComponent<EnemyHealth>();
            enemyHealth.OnAttack(this.damage, hitInfo.point);


            //设置线段终点位置      射线的碰撞位置
            line.SetPosition(1,  hitInfo.point);
        }
        else
        {
            //设置线段的终点位置      起始位置             +  枪的前方100米的位置
            line.SetPosition(1,   gunPos.position + gunPos.forward * 100f);
        }

    }

    //隐藏特效
    void HideEffects()
    {
        lights[0].enabled = false;
        lights[1].enabled = false;
        line.enabled = false;
    }
}
