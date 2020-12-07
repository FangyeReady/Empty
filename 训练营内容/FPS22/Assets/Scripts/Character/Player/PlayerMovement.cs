using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigid;
    Animator ani;
    PlayerHealth health;

    //使用public 可以在检视面板修改属性
    public float speed = 2;

    private void Start()
    {
        /*
           CTRL + K,  CTRL + C  多行注释

           CTRL + K,  CTRL + U  解除注释
        */
        //Debug.Log("测试代码~~~~1");

        //赋值
        rigid = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        health = GetComponent<PlayerHealth>();

    }

    private void FixedUpdate()
    {
        //逻辑代码 
        bool isDeadth = health.IsDead();
        if (isDeadth)
        {
            return;//代码在此处终结
        }


        Move();
        Turing();
        Animating();
    }


    /// <summary>
    /// 移动的方法
    /// </summary>
    public void Move()
    {
        //得到水平增量
        float h = Input.GetAxis("Horizontal");
        //得到垂直增量
        float v = Input.GetAxis("Vertical");
        //通过水平和垂直增量,获取坐标系中的移动方向
        Vector3 dir = new Vector3( h, 0, v );
        //通过方向获取移动量
        Vector3 movement = dir.normalized * Time.deltaTime * speed;
        //使用移动量
        rigid.MovePosition( transform.position +  movement);
    }

    public void Turing()
    {
        //利用鼠标的位置创建了一个从屏幕向游戏世界发射的射线
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        //创建一个碰撞信息的变量
        RaycastHit hitInfo;

        //检测碰撞                  检测的射线   检测的结果信息    射线的长度   检测的目标
        bool isHit = Physics.Raycast(ray,  out hitInfo,     100f,  LayerMask.GetMask("Ground"));
        if (isHit)
        {
            //得到射线碰撞交点
            Vector3 point = hitInfo.point;
            //得到角色朝向碰撞点的向量
            Vector3 dir = point - transform.position;
            dir.y = 0;

            //利用向量得到角色面对碰撞点的旋转量
            Quaternion rotation = Quaternion.LookRotation( dir );
            //旋转角色
            rigid.MoveRotation(rotation);
        }
    }





    /// <summary>
    /// 控制动画
    /// </summary>
    public void Animating()
    {

        //得到水平增量
        float h = Input.GetAxis("Horizontal");
        //得到垂直增量
        float v = Input.GetAxis("Vertical");

        //判断是否在水平或垂直方向移动
        bool isWalking = h != 0 || v != 0;
        
        //设置动画状态
        ani.SetBool("IsWalking", isWalking);
    }




}
