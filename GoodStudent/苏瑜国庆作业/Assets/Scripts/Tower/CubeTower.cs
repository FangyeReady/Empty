using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTower : MonoBehaviour
{
    public int distance = 5;//攻击距离
    private float restTime = 0.2f;
    private float timer = 0;

    public GameObject Bullet;
    public Transform firePoint;
    private GameObject target;//目标敌人
    private Transform bulletFather;
    private Animator anim;
    private AnimatorStateInfo stateInfo;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bulletFather = GameObject.Find("BulletFather").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        TowerRotation();
        target = SelectTarget();
        if (target != null)
        {
            anim.SetTrigger("Fire");
        }
        if (stateInfo.IsName("CubeTower")&&stateInfo.normalizedTime>=0.99)
        {
            CubeFire();
        }
        
    }

    //控制旋转角度的方法
    void TowerRotation()
    {
        Vector3 target_pos = Vector3.zero;
        GameObject go = SelectTarget();
        if (go!=null)
        {
            target_pos = go.transform.position;
        }
        Vector3 my_pos = transform.position;
       transform.right = target_pos - my_pos;
    }

    //选择范围内最近的目标
    GameObject SelectTarget() {
        for (int i = 1; i < GameManager.instance.spiderList.Count; i++)
        {
            float distance1 = Vector2.Distance(transform.position, GameManager.instance.spiderList[i-1].transform.position);
            float distance2 = Vector2.Distance(transform.position, GameManager.instance.spiderList[i].transform.position);
            if (distance1>distance2)
            {
                if (distance2<=distance)
                {
                    target = GameManager.instance.spiderList[i];
                }
            }
            else
            {
                if (distance1<=distance)
                {
                    target = GameManager.instance.spiderList[i - 1];
                }
            }
        }
        return target;
    }

    //开炮方法
    void CubeFire() {
        if (timer>=restTime)
        {
            GameObject go = Instantiate(Bullet, firePoint.position, firePoint.rotation);
            go.transform.SetParent(bulletFather);
            timer = 0;
        }
    }

}
