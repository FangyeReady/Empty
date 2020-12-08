﻿using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;
/*九城教育*/
public class PlayerShooting : MonoBehaviour
{
    //灯光
    public Light light1;
    public Light light2;

    //枪的射线
    public LineRenderer line;

    //音效
    public AudioSource shootAudio;
    //开枪效果
    public ParticleSystem fireEffect;
    //生命值
    public PlayerHealth health;

    //攻击力
    public float Attack = 2;

    //特效持续时间
    float effectHoldTime = 0.05f;
    //计时器
    float timer = 0f;

    //游戏界面
    GameView gameView;



    private void Start()
    {
        //赋值
        gameView = GameObject.FindObjectOfType<GameView>();
    }


    private void Update()
    {
        //如果游戏未开始,则在此处终结代码
        if (!gameView.IsStartingGame)
        {
            return;
        }

        bool isDeadth = health.IsDead();
        if (isDeadth)
        {
            return;//代码在此处终结
        }

        timer += Time.deltaTime;

#if !UNITY_EDITOR
        //响应鼠标左键
        if ( Input.GetButton("Fire1") && timer > 0.15f  )
        {
            Shooting();
            //Debug.Log("开枪~~~~");
        }

        //鼠标抬起
        if (Input.GetButtonUp("Fire1"))
        {
            //light1.enabled = false;
            //light2.enabled = false;
            //禁用枪的射线
            line.enabled = false;
        }
#else
        bool isMoveX = CrossPlatformInputManager.GetAxis("Horizontal") != 0;
        bool isMoveY = CrossPlatformInputManager.GetAxis("Vertical") != 0;
        bool isMove = isMoveX || isMoveY;

        if ( isMove && timer > 0.15f )
        {
            Shooting();
            //Debug.Log("开枪~~~~");
        }

#endif


        if (timer >= effectHoldTime)
        {
            //禁用灯光
            light1.enabled = false;
            light2.enabled = false;
            //禁用枪的射线
            line.enabled = false;
        }
        
    }


    /// <summary>
    /// 开火的方法
    /// </summary>
    private void Shooting()
    {
        //重置时间
        timer = 0f;

        //启用灯光
        light1.enabled = true;
        light2.enabled = true;

        //启用枪的射线
        line.enabled = true;

        //播放音效
        shootAudio.Play();
        //播放开枪特效
        fireEffect.Stop();
        fireEffect.Play();

        //设置线段
        //设置线段的起始位置
        line.SetPosition(0, transform.position);

        //创建射线
        Ray ray = new Ray();
        //设置射线的起始位置
        ray.origin = transform.position;
        //设置射线的方向
        ray.direction = transform.forward;

        //Debug.DrawRay(ray.origin, ray.direction, Color.red, 3f);


        //碰撞信息
        RaycastHit hitInfo;
        //检测碰撞
        bool isHit = Physics.Raycast(ray, out hitInfo, 100f, LayerMask.GetMask("Enemy", "Ground"));
        if (isHit)
        {
            //如果碰到了敌人,则射线终点为碰撞点  
            line.SetPosition(1, hitInfo.point + new Vector3(0, 1f, 0));

            //控制敌人掉血
            EnemyHealth enemy = hitInfo.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {

                //得到分数       
                int score = gameView.GetScore();
                float addAtk = Mathf.Floor(score / 500f);
                float curAtk = Attack + addAtk;
                if (curAtk > 5)
                {
                    curAtk = 5;
                }

                //Debug.Log("攻击力:" + curAtk);
                
                enemy.OnHurt(curAtk, hitInfo.point);
            }
        }
        else
        {
            //如果没有碰撞到敌人,则终点为自身前方100米
            line.SetPosition(1, transform.position + transform.forward * 100f);
        }


    }


}
