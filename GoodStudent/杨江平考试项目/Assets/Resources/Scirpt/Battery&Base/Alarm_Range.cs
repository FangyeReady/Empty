using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm_Range : MonoBehaviour
{
    public float range;
    public float rotespeed;
    public GameObject target;
    public Transform Birth_Bullet;
    public GameObject Bullet;
    public float timer = 1.0f;
    //  GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        /*        range = 30f;
                rotespeed = 5f;
                target = null;*/
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();
        
    }
    void UpdateTarget()     
    {
        float Min_distance = Mathf.Infinity;
        GameObject nearEnemy = null ;
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
        if (Min_distance < range)
        {
            target = nearEnemy;
            LookTarget();
            Fire();
        }
        else
        {
            target = null;
        }

    }



    void LookTarget()
    {
        Vector3 a = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(a);
        Quaternion LERP = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotespeed);
        transform.rotation = LERP;
    }
    void Fire()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameObject bullet = GameObject.Instantiate(Bullet);
            bullet.transform.parent = GameObject.Find("Bullet_box").transform;
            bullet.transform.position = Birth_Bullet.position;
            bullet.transform.rotation = Birth_Bullet.rotation;
/*            Vector3 b = target.transform.position - bullet.transform.position;
            Quaternion pos = Quaternion.LookRotation(b);
            bullet.transform.rotation = Quaternion.Lerp(bullet.transform.rotation, pos, Time.deltaTime * rotespeed * 10);*/
            timer = 1.0f;
            Destroy(bullet, 8);
        }
    }




    //给炮台画出攻击范围，只在选中时候绘制,   OnDrawGizmos()这个是 无论选没选都会绘制

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // 线的颜色为红色；
        // Gizmos.DrawWireSphere这是画一个球体，第一参数是图画的重心，第二个参数是，图画半径， 要画其他的就Gizmos.  出其他的； 
        Gizmos.DrawWireSphere(transform.position, range);
        
    }
}
