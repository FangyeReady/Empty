using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Speed1 : MonoBehaviour
{
    /// <summary>
    /// 迫击炮弄失败了 但是基础抛物线是有了的。失败原因：目标敌人也在移动，自己逻辑是考虑到了的，但是移动后的中间的路径向量长度都能拿到，但是中间就是数据有问题，炮弹始终落在后面= =，调试了很久，然后如果目标不动的话是一定能打上的。
    /// 所以自己认为就是那个目标的位移距离并没有加到炮弹的飞行时间上，弄了很久，就没弄了
    /// </summary>
   // float time;
   // float g = 9.8f;
    Rigidbody rig;
   //float Vt;
   // public Vector3 a, Move_Speed;
    public float Force = 10;
    public float rotespeed;
    //float start_speed = 40f;
    public GameObject target;
    public float timer = 1.0f;
    // EnemyMoves moves;  这个方式拿不到  目标的速度！！
    // Alarm_Range tar;
    //GameObject _Targt;
    //Vector3 Distance_Vector;
    void Start()
    {
        rotespeed = 5f;
        rig = GetComponent<Rigidbody>();
        rig.AddRelativeForce(transform.forward * 150, ForceMode.Acceleration);





        /*        Vector3 D_Vector = transform.position-target.transform.position;                                //  1111      这个方向向量应该是 目标指向炮弹，和我先打个相反
                a= Vector3.Normalize(D_Vector);                                                                 //  2222      好像取得单位向量的时候方向会改变
             //   rig.AddRelativeForce(a * Force, ForceMode.VelocityChange);
             //   float start_speed = rig.velocity.magnitude;  ////////////////////////////////////////////!!!!!!这个就可以直接得到 速度！！！！！！数值的不是 向量!!!但是 和dis/float得到的不一样
                float Distance = Vector3.Distance(transform.position, target.transform.position);
                float T = Distance / start_speed;
                //a = D_Vector / T;
                float t = T / 2;
                Vt = g * t;
                Debug.LogWarning(Vt);


                _Targt = GameObject.FindGameObjectWithTag("Player_Base");
                Distance_Vector = _Targt.transform.position - target.transform.position;

                //      float a = velocity();
                //      rig.AddRelativeForce(transform.forward * a, ForceMode.VelocityChange);*/
    }
    private void FixedUpdate()
    {



    }


    // Update is called once per frame
    void Update()
    {


        /*        Move_Speed = Vector3.Normalize(Distance_Vector) * Time.deltaTime * 2;

                if (target.transform.position.y > transform.position.y)
                {
                    return;
                }
                time += Time.deltaTime;
                float test = Vt - g * time;
                Vector3 s = new Vector3();
                // transform.Translate(Vector3.forward * Time.deltaTime * 100);
                transform.Translate(Vector3.forward * start_speed * Time.deltaTime);
                transform.Translate(transform.up * test * Time.deltaTime);*/

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            UpdateTarget();

            Vector3 b = target.transform.position - transform.position;
            Quaternion pos = Quaternion.LookRotation(b);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos, Time.deltaTime * rotespeed*1.5f );
            transform.position = transform.forward * 0.3f + transform.position;
        }
    }
    /// <summary>
    /// 我这里想弄成迫击炮 那种效果，就是炮弹会提前指向你当前速度不变的走下去的位置，就是有个预判那种样式。
    /// </summary>
    /// <returns></returns>
    /*    float velocity()
        {
            float g = 9.8f;                    // 得到重力加速度                        
            Vector3 v2 = this.rig.velocity/ Time.deltaTime;  // 拿到子弹的移动速度和方向



            //这儿 想拿到 在Alarm_Range脚本里面得到的那个最近的敌人， 然后直接进行获取目标的速度等，然后一直失败。。。就是炮弹一创建出来就遇到NullRNullReferenceException;这个错误
            // 感觉很像是就是没找到或者就是 不能这样吧！！ 其他的 NullReferenceException: Object reference not set to an instance of an object------所以下面也进行了敌人的遍历，来获取目标


            *//*      GameObject _Targt = GameObject.FindGameObjectWithTag("Player_Base");
                    Vector3 Distance_Vector = _Targt.transform.position - tar.target.transform.position;                                //得到目标的移动向量

                    Vector3 v1 = Vector3.Normalize(Distance_Vector) * 0.05f;                 /// moves.Move_Speed;这个 拿不到            // 拿到目标的移动速度和方向
            *//*




            // 感觉逻辑是对的，但是数据不对，可能是不能这样弄，方法不对
    *//*


        GameObject Enemy_Targt = GameObject.FindGameObjectWithTag("Player_Base");
        Vector3 Distance_Vector = Enemy_Targt.transform.position - target.transform.position;
        Vector3 v1 = Vector3.Normalize(Distance_Vector) * 0.05f / Time.deltaTime;
        float x = Vector3.Distance(target.transform.position, transform.position);               //拿到目标与子弹的当前距离x, 子弹与目标的连线！！
        Vector3 fangxiang = (target.transform.position - transform.position).normalized;         //得到子弹指向目标的方向 单位向量a 也与该连线重合
        Vector3 va1 = Vector3.Project(v1, fangxiang) ;                                                //得到目标自身在方向 单位向量a上的分速度va1向量
        Vector3 va2 = Vector3.Project(v2, fangxiang) ;                                                //得到子弹自身在方向 单位向量a上的分速度va2向量
        Vector3 va3 = Vector3.Project(v2, transform.up) ;                                             //得到子弹在Y轴上的速度向量

        float v11 = Vector3.Dot(va1, fangxiang)/Time.deltaTime;                //得到目标自身在方向 单位向量a上的分速度v1'
        float v22 = Vector3.Dot(va2, fangxiang)/Time.deltaTime;                //得到子弹自身在方向 单位向量a上的分速度v2'
        float vy1 = Vector3.Dot(va3, transform.up)/Time.deltaTime;             //得到子弹自身在方向 y轴上的分速度vy1
        Debug.Log("目标fen"+v11+ "子弹fen" + v22 + "y轴上fen" + vy1);

                                                                // 满足条件 v1'*t+x=v2'*t ===> t=x/(v2'-v1')
            float t = x / (v22 - v11);                          // 得到时间
                                                                // 满足条件 vy2(现在要给予的)+vy=g*t  ===> vy2=g*t-vy1
        float v = g * t - vy1;






            return v;

        }
    */


    void UpdateTarget()
    {
        float Min_distance = Mathf.Infinity;
        GameObject nearEnemy = null;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var Enemy in enemy)
        {
            float dis = Vector3.Distance(Enemy.transform.position, transform.position);
            if (Min_distance > dis)
            {
                Min_distance = dis;
                nearEnemy = Enemy;
            }
        }
       target = nearEnemy;
        /*        
                if (Min_distance < range)
                {
                    target = nearEnemy;
                    LookTarget();
                    Fire();
                }
                else
                {
                    target = null;
                }*/

    }
}
