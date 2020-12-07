using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PlayerMovement : MonoBehaviour
{
    //移动速度
    public float moveSpeed = 10f;
    //获得刚体(物理系统)
    //public Rigidbody rigid;
    private Rigidbody rigid;
    //获得动画组件
    private Animator anim;
    //射线碰撞信息
    private RaycastHit hitInfo;
    //玩家生命值
    private PlayerHealth health;

    private void Awake()
    {
        //对组件进行赋值
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        health = GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        //如果玩家死亡,则不继续下面的移动代码
        if (health.IsDead())
        {
            return;
        }

        //获取水平增量
        float  hOffset = Input.GetAxis("Horizontal");

        //获取竖直增量
        float  vOffset = Input.GetAxis("Vertical");

        //移动
        Move(hOffset, vOffset);

        //转向
        Turining();

        //调用
        Animating(hOffset, vOffset);
    }

    //移动的方法
    private void Move(float hOffset, float vOffset)
    {
        //获取变化方向
        Vector3 moveDir = new Vector3(hOffset, 0f, vOffset);

        //计算本次移动量
        Vector3 moveMent = moveDir.normalized * Time.deltaTime * moveSpeed;

        //移动
        //transform.Translate()
        rigid.MovePosition(transform.position + moveMent);
    }
 
    
    //动画的方法
    private void Animating(float h ,  float v)
    {
        bool isWalking = h != 0 || v != 0;

        anim.SetBool("IsWalking", isWalking);
    }

    //角色转向
    private void Turining()
    {
        //围绕鼠标旋转
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

        //使用射线                     射线     射线的碰撞信息    射线最大距离     射线的碰撞层
        bool isHit =  Physics.Raycast( ray,    out hitInfo,       100f,               LayerMask.GetMask("Ground"));

        //如果碰到了东西
        if (isHit)
        {
            //碰撞点的坐标
            Vector3 hitPoint = hitInfo.point;

            //Player朝向碰撞点的一个向量
            Vector3 dir = hitPoint - transform.position;
            dir.y = 0f;

            //得到一个旋转量的四元数
            Quaternion targetRotation = Quaternion.LookRotation(dir);

            //旋转， 转向
            rigid.MoveRotation( targetRotation );
        }
    }
    

}
