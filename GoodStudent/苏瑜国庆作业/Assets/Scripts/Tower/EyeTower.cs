using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTower : MonoBehaviour
{
    public int distance = 6;//攻击距离
    private float restTime = 1f;
    private float timer = 0;

    public GameObject Bullet;
    public Transform firePoint;
    private GameObject target;//目标敌人
    private Transform bulletFather;
    // Start is called before the first frame update
    void Start()
    {
        bulletFather = GameObject.Find("BulletFather").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        target = SelectTarget();
        if (target!=null)
        {
            TowerRotation();
            EyeFire();
        }
    }
    //控制攻击方向的方法
    void TowerRotation()
    {
        Vector3 target_pos = Vector3.zero;
        GameObject go = SelectTarget();
        if (go != null)
        {
            target_pos = go.transform.position;
        }
        Vector3 my_pos = firePoint.position;
        firePoint.right = target_pos - my_pos;
    }

    //选择范围内最近的目标
    GameObject SelectTarget()
    {
        for (int i = 1; i < GameManager.instance.junkManList.Count; i++)
        {
            float distance1 = Vector2.Distance(transform.position, GameManager.instance.junkManList[i - 1].transform.position);
            float distance2 = Vector2.Distance(transform.position, GameManager.instance.junkManList[i].transform.position);
            if (distance1 > distance2)
            {
                if (distance2 <= distance)
                {
                    target = GameManager.instance.junkManList[i];
                }
            }
            else
            {
                if (distance1 <= distance)
                {
                    target = GameManager.instance.junkManList[i - 1];
                }
            }
        }
        return target;
    }

    //发射火球方法
    void EyeFire()
    {
        if (timer >= restTime)
        {
            GameObject go = Instantiate(Bullet, firePoint.position, firePoint.rotation);
            go.transform.SetParent(bulletFather);
            timer = 0;
        }
    }
}
