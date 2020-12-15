using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
/*九城教育*/
public class EnemyBoss : MonoBehaviour
{
    //枪口
    public Transform point1;
    public Transform point2;
    public Transform pointMid;
    //子弹
    public GameObject bulletPrefab;
    //攻击间隔
    public float fireInterval = 0.3f;
    float timer = 0f;

    //玩家
    Transform player;
    BossHealth bossHealth;
    float preHealth = 0f;

    bool isFireSkill1 = false;
    bool isFireSkill2 = false;

    float percent = 0f;

    private void Start()
    {
        //玩家查找赋值
        player = GameObject.FindGameObjectWithTag("Player").transform;

        bossHealth = GetComponent<BossHealth>();

        //预存Boss的生命值
        preHealth = bossHealth.Health;



        StartCoroutine(Skill1());
        StartCoroutine(Skill2());

    }


    private void Update()
    {

        if (transform.position.z > 90f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 6f);
            return;
        }


        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            timer = 0f;
            //开火
            Fire();
        }

        if (preHealth - bossHealth.Health >= 50)
        {
            preHealth = bossHealth.Health;

            //释放技能1
            isFireSkill1 = true;
        }
        else
        {
            isFireSkill1 = false;
        }

        if (bossHealth.Health < 300)
        {
            //释放技能2
            isFireSkill2 = true;
        }


        //开启技能2时调用
        if (isFireSkill2)
        {
            float y = Mathf.PingPong(percent, 240);
            pointMid.localRotation = Quaternion.Euler(0, -120 + y, 0);
            percent += 6f;
        }
        else
        {
            percent = 0f;
            pointMid.rotation = Quaternion.identity;
        }
    }


    void Fire()
    {
        if (player == null)
        {
            return;
        }

        //得到方向
        Vector3 dir1 = player.position - point1.position;
        Vector3 dir2 = player.position - point2.position;
        //得到旋转量
        Quaternion rotation1 = Quaternion.LookRotation(dir1);
        Quaternion rotation2 = Quaternion.LookRotation(dir2);
        //旋转
        point1.localRotation = rotation1;
        point2.localRotation = rotation2;
        //发射子弹
        Instantiate(bulletPrefab, point1.position, point1.localRotation);
        Instantiate(bulletPrefab, point2.position, point2.localRotation);
    }


    IEnumerator Skill1()
    {
        while (true)
        {
            yield return new WaitUntil(() => { return isFireSkill1; });


            for (int i = 0; i < 2; i++)
            {
                for (int j = -10; j <= 10; j++)
                {
                    Instantiate(bulletPrefab, pointMid.position, Quaternion.Euler(0, 180 - j * 12, 0));
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }

    IEnumerator Skill2()
    {
        while (true)
        {
            yield return new WaitUntil(() => { return isFireSkill2; });

            Instantiate(bulletPrefab, pointMid.position, pointMid.rotation);
            yield return new WaitForSeconds(0.05f);

        }
    }



}
