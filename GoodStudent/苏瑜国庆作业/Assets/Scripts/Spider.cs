using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spider : MonoBehaviour
{
    private enum State {
        Moving,
        ChaseTarget,
        Attacking,
        Death
    }

    public static Spider instance;
    public int speed = 5;//移动速度
    public int baseAttack = 6;//基础攻击力
    [HideInInspector]
    public int attack;//实际攻击力
    public int hp1 = 20;//血量
    private float restTime = 0.6f;//攻击间隔
    private float timer = 0;
    private GameObject target;//目标敌人

    private State state;//状态信息
    private Animator anim;
    private SpriteRenderer spriteRenderer1;
    private Color originColor;
    //移动点位
    private Transform upPoint1;
    private Transform upPoint2;
    private Transform upPoint3;
    private Transform midPoint1;
    private Transform downPoint1;
    private Transform downPoint2;
    private Transform downPoint3;

    public GameObject attackShape1;
    public GameObject damgeCanvas;

    private bool up1Done = true;
    private bool up2Done = false;
    private bool up3Done = false;
    private bool mid1Done = true;
    private bool down1Done = true;
    private bool down2Done = false;
    private bool down3Done = false;
    [HideInInspector]
    public bool isAttacked1 = false;

    private void Awake()
    {
        instance = this;
        state = State.Moving;//开始设为移动状态
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer1 = GetComponent<SpriteRenderer>();
        originColor = spriteRenderer1.color;
        upPoint1 = GameObject.Find("EyeUpPoint1").transform;
        upPoint2 = GameObject.Find("EyeUpPoint2").transform;
        upPoint3 = GameObject.Find("EyeUpPoint3").transform;
        midPoint1 = GameObject.Find("EyeMidPoint1").transform;
        downPoint1 = GameObject.Find("EyeDownPoint1").transform;
        downPoint2 = GameObject.Find("EyeDownPoint2").transform;
        downPoint3 = GameObject.Find("EyeDownPoint3").transform;

        //attackShape =gameObject.transform.Find("AttackShape1").gameObject;
    }
    private void FixedUpdate()
    {
        attack = Random.Range(baseAttack, baseAttack + 10);//随机攻击力
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        switch (state)
        {
            case State.Moving:
                SpiderMove();
                break;
            case State.ChaseTarget:
                SpiderChaseTarget();
                break;
            case State.Attacking:
                if (hp1 <= 0)
                {
                    state = State.Death;
                }
                if (target == null)
                {
                    state = State.Moving;
                    return;
                }
                if (timer>=restTime)
                {
                    SpiderAttack();
                    timer = 0;
                }
                break;
            case State.Death:
                IsDeath();
                break;
            default:
                break;
        }
    }
    //=====爆浆虫移动方法=====
    void SpiderMove() {
        speed = 1;
        //先判断附近是否有敌人
        foreach (var item in GameManager.instance.junkManList)
        {
            float distance = Vector2.Distance(transform.position, item.transform.position);
            if (distance <= 1.5)//如果有距离敌人小于2,就将状态设为追击敌人
            {
                target = item;//确定目标敌人
                state = State.ChaseTarget;
                return;
            }
        }
        //====上路爆浆虫=====
        if (transform.tag == "goUp1")
        {   //完成up1位置
            if (up1Done == true)
            {
                anim.SetInteger("isRunning", 1);
                transform.position = Vector2.MoveTowards(transform.position, upPoint1.position, speed * Time.deltaTime);
            }
            if (transform.position == upPoint1.position)//表示已经到达上面1号位置
            {
                anim.SetInteger("isRunning", 0);
                up1Done = false;
                up2Done = true;
            }
            //完成up2位置
            if (up2Done == true)
            {
                anim.SetInteger("isRunning", 1);
                transform.position = Vector2.MoveTowards(transform.position, upPoint2.position, speed * Time.deltaTime);
            }
            if (transform.position == upPoint2.position)//表示已经到达上面2号位置
            {
                anim.SetInteger("isRunning", 0);
                up2Done = false;
                up3Done = true;
            }
            //完成up3位置
            if (up3Done == true)
            {
                anim.SetInteger("isRunning", 1);
                transform.position = Vector2.MoveTowards(transform.position, upPoint3.position, speed * Time.deltaTime);
            }
            if (transform.position == upPoint3.position)//表示已经到达上面3号位置
            {
                anim.SetInteger("isRunning", 0);
                anim.SetTrigger("attack");//攻击基地
            }
        }
        //====中路爆浆虫====
        if (transform.tag == "goMid1" && mid1Done == true)
        {
            anim.SetInteger("isRunning", 1);
            transform.position = Vector2.MoveTowards(transform.position, midPoint1.position, speed * Time.deltaTime);
            if (transform.position == midPoint1.position)//表示已经到达上面1号位置
            {
                anim.SetInteger("isRunning", 0);
                anim.SetTrigger("attack");//攻击基地
            }
        }
        //====下路爆浆虫====
        if (transform.tag == "goDown1")
        {   //完成down1位置
            if (down1Done == true)
            {
                anim.SetInteger("isRunning", 1);
                transform.position = Vector2.MoveTowards(transform.position, downPoint1.position, speed * Time.deltaTime);
            }
            if (transform.position == downPoint1.position)//表示已经到达上面1号位置
            {
                anim.SetInteger("isRunning", 0);
                down1Done = false;
                down2Done = true;
            }
            //完成down2位置
            if (down2Done == true)
            {
                anim.SetInteger("isRunning", 1);
                transform.position = Vector2.MoveTowards(transform.position, downPoint2.position, speed * Time.deltaTime);
            }
            if (transform.position == downPoint2.position)//表示已经到达上面2号位置
            {
                anim.SetInteger("isRunning", 0);
                down2Done = false;
                down3Done = true;
            }
            //完成down3位置
            if (down3Done == true)
            {
                anim.SetInteger("isRunning", 1);
                transform.position = Vector2.MoveTowards(transform.position, downPoint3.position, speed * Time.deltaTime);
            }
            if (transform.position == downPoint3.position)//表示已经到达上面3号位置
            {
                anim.SetInteger("isRunning", 0);
                anim.SetTrigger("attack");//攻击基地
            }
        }

    }

    //=====爆浆虫追击方法======
    void SpiderChaseTarget() {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance<=0.65)
        {
            speed = 0;
            anim.SetInteger("isRunning", 0);
            state = State.Attacking;//转为攻击状态
        }
    }

    //=====爆浆虫攻击方法======
    void SpiderAttack() {
        if(hp1 <= 0)
        {
            state = State.Death;
            return;
        }
        if (target!=null)
        {
            if (target.GetComponent<JunkMan>().hp<=0)
            {
                state = State.Moving;
                return;
            }
        }
        anim.SetTrigger("attack");
        if (hp1 <= 0)
        {
            state = State.Death;
            return;
        }
    }

    //=====生成攻击判定框====
    public void SpiderAttackShape() {
        Instantiate(attackShape1, transform.position, transform.rotation);
    }

    //======被攻击变红方法=====
    void FlashRed(float time) {
        spriteRenderer1.color = Color.red;
        Invoke("resetColor", time);
    }
    void resetColor() {
        spriteRenderer1.color = originColor;
    }

    //=====被攻击触发器====
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            print("aaaaaaaaaaa");
            FlashRed(0.2f);
            hp1 -= 5;
            DamageNum damage = Instantiate(damgeCanvas, transform.position, Quaternion.identity).GetComponent<DamageNum>();
            damage.ShowUIDamage(5);
            if (hp1 <= 0)
            {
                state = State.Death;
            }
        }
        if (collision.tag=="AttackShape2")
        {
            if (isAttacked1 == false)
            {
                print("爆浆虫被攻击了");
                FlashRed(0.2f);
                isAttacked1 = true;
                StartCoroutine(isAttackCo());
                hp1 -= JunkMan.instance.attack;
                DamageNum damage = Instantiate(damgeCanvas, transform.position, Quaternion.identity).GetComponent<DamageNum>();
                damage.ShowUIDamage(JunkMan.instance.attack);//显示伤害
                print("拾荒者攻击力:" + JunkMan.instance.attack);
                if (hp1 <= 0)
                {
                    state = State.Death;
                }
                print("爆浆虫的hp:" + hp1);
            }
        }  
    }

    //=====死亡方法=====
    void IsDeath() {
            speed = 0;
            spriteRenderer1.sortingOrder = -1;
            anim.SetTrigger("isDeath");
            GameManager.instance.spiderList.Remove(this.gameObject);
            Destroy(this.gameObject, 1);
    }
    //销毁时增加金币
    private void OnDestroy()
    {
        GameManager.instance.cubeCoin += 10;
    }

    IEnumerator isAttackCo() {
        yield return new WaitForSeconds(0.2f);
        isAttacked1 = false;
    }
}
