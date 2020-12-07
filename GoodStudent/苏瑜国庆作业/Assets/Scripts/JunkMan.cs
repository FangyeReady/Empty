using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkMan : MonoBehaviour
{
    private enum State//状态信息
    {
        Moving,
        ChaseTarget,
        Attacking,
        Death
    }

    public static JunkMan instance;
    public int speed = 1;//移动速度
    public int baseAttack = 10;//基础攻击力
    [HideInInspector]
    public int attack;//实际攻击力
    public int hp = 20;//血量
    private float restTime = 1;//攻击间隔
    private float timer = 0;

    private GameObject target;//目标敌人
    private State state;//状态信息
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer2;
    private Color originColor;
    //移动点位
    private Transform upPoint1;
    private Transform upPoint2;
    private Transform upPoint3;
    private Transform midPoint1;
    private Transform downPoint1;
    private Transform downPoint2;
    private Transform downPoint3;

   public GameObject attackShape2;
   public GameObject damageCanvas;

    private bool up1Done = true;
    private bool up2Done = false;
    private bool up3Done = false;
    private bool mid1Done = true;
    private bool down1Done = true;
    private bool down2Done = false;
    private bool down3Done = false;
    [HideInInspector]
    public bool isAttacked2 = false;

    private void Awake()
    {
        instance = this;
        state = State.Moving;//开始设为移动状态
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer2 = GetComponent<SpriteRenderer>();
        originColor = spriteRenderer2.color;
        upPoint1 = GameObject.Find("CubeUpPoint1").transform;
        upPoint2 = GameObject.Find("CubeUpPoint2").transform;
        upPoint3 = GameObject.Find("CubeUpPoint3").transform;
        midPoint1 = GameObject.Find("CubeMidPoint1").transform;
        downPoint1 = GameObject.Find("CubeDownPoint1").transform;
        downPoint2 = GameObject.Find("CubeDownPoint2").transform;
        downPoint3 = GameObject.Find("CubeDownPoint3").transform;

        //attackShape = this.gameObject.transform.Find("AttackShape2").gameObject;
    }
    private void FixedUpdate()
    {
        attack = Random.Range(baseAttack, baseAttack + 7);//随机攻击力
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        switch (state)
        {
            case State.Moving:
                JunkManMove();
                break;
            case State.ChaseTarget:
                JunkManChaseTarget();
                break;
            case State.Attacking:
                if (hp <= 0)
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
                    JunkManAttack();
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
    //=====拾荒者移动方法======
    void JunkManMove() {
        speed = 1;
        //先判断附近是否有敌人
        foreach (var item in GameManager.instance.spiderList)
        {
            float distance = Vector2.Distance(transform.position, item.transform.position);
            if (distance <= 1.5)//如果有距离敌人小于1.5,就将状态设为追击敌人
            {
                target = item;//确定目标敌人
                state = State.ChaseTarget;//改为追击敌人状态
                return;
            }
        }
        //====上路拾荒者=====
        if (transform.tag=="goUp")
        {   //完成up1位置
            if (up1Done==true)
            {
                anim.SetInteger("isRunning", 1);
                transform.position = Vector2.MoveTowards(transform.position, upPoint1.position, speed * Time.deltaTime);
            }
            if (transform.position==upPoint1.position)//表示已经到达上面一号位置
            {
                anim.SetInteger("isRunning", 0);
                up1Done = false;
                up2Done = true;
            }
            //完成up2位置
            if (up2Done==true)
            {
                anim.SetInteger("isRunning", 1);
                transform.position = Vector2.MoveTowards(transform.position, upPoint2.position, speed * Time.deltaTime);
            }
            if (transform.position == upPoint2.position)//表示已经到达上面一号位置
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
            if (transform.position == upPoint3.position)//表示已经到达上面一号位置
            {
                anim.SetInteger("isRunning", 0);
                anim.SetTrigger("attack");//攻击基地
            }
        }
        //====中路拾荒者====
        if (transform.tag == "goMid" && mid1Done == true)
        {
            anim.SetInteger("isRunning", 1);
            transform.position = Vector2.MoveTowards(transform.position, midPoint1.position, speed * Time.deltaTime);
            if (transform.position == midPoint1.position)//表示已经到达上面一号位置
            {
                anim.SetInteger("isRunning", 0);
                anim.SetTrigger("attack");//攻击基地
            }
        }
        //====下路拾荒者====
        if (transform.tag == "goDown")
        {   //完成down1位置
            if (down1Done == true)
            {
                anim.SetInteger("isRunning", 1);
                transform.position = Vector2.MoveTowards(transform.position, downPoint1.position, speed * Time.deltaTime);
            }
            if (transform.position == downPoint1.position)//表示已经到达上面一号位置
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
            if (transform.position == downPoint2.position)//表示已经到达上面一号位置
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
            if (transform.position == downPoint3.position)//表示已经到达上面一号位置
            {
                anim.SetInteger("isRunning", 0);
                anim.SetTrigger("attack");//攻击基地
            }
        }

    }

    //=====拾荒者追击敌人方法======
    void JunkManChaseTarget() {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance <= 0.65)
        {
            speed = 0;
            anim.SetInteger("isRunning", 0);
            state = State.Attacking;//转为攻击状态
        }
    }

    //=====拾荒者攻击方法=====
    void JunkManAttack() {
        if (hp<=0)
        {
            state = State.Death;
            return;
        }
        if (target != null)
        {
            if (target.GetComponent<Spider>().hp1 <= 0)
            {
                state = State.Moving;
                return;
            }
        }
        anim.SetTrigger("attack");
        if (target == null)
        {
            state = State.Moving;
            return;
        }
        if (hp <= 0)
        {
            state = State.Death;
            return;
        }
    }
    //=====出现攻击判定框=====
    public void JunkManAttackShape() {
        Instantiate(attackShape2, transform.position, transform.rotation);
    }
    //被攻击变红方法
    void FlashRed(float time)
    {
        spriteRenderer2.color = Color.red;
        Invoke("resetColor", time);
    }
    void resetColor()
    {
        spriteRenderer2.color = originColor;
    }
    //=====被攻击收到伤害=====
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fireBullet")
        {
            print("sssssssssssss");
            FlashRed(0.2f);
            hp -= 5;
            DamageNum damage = Instantiate(damageCanvas, transform.position, Quaternion.identity).GetComponent<DamageNum>();
            damage.ShowUIDamage(5);
            if (hp <= 0)
            {
                state = State.Death;
            }
        }
        if (collision.tag=="AttackShape1")
        {
            if (isAttacked2 == false)
            {
                print("拾荒者被攻击了");
                FlashRed(0.2f);
                isAttacked2 = true;
                StartCoroutine(isAttackCo());
                hp -= Spider.instance.attack;
                DamageNum damage = Instantiate(damageCanvas, transform.position, Quaternion.identity).GetComponent<DamageNum>();
                damage.ShowUIDamage(Spider.instance.attack);
                print("爆浆虫攻击力:" + Spider.instance.attack);
                if (hp <= 0)
                {
                    state = State.Death;
                }
                print("拾荒者的hp:" + hp);
            }
        }
    }

    //=====死亡方法=====
    void IsDeath() {
            Debug.LogWarning("调用isDeath~~~~1");
            speed = 0;
            spriteRenderer2.sortingOrder = -1;
            anim.SetTrigger("isDeath");
            Debug.LogWarning("调用isDeath~~~~2");
            GameManager.instance.junkManList.Remove(this.gameObject);
            Destroy(this.gameObject, 1.5f);
    }
    private void OnDestroy()
    {
        GameManager.instance.eyeCoin += 10;
    }
    IEnumerator isAttackCo()
    {
        yield return new WaitForSeconds(0.2f);
        isAttacked2 = false;
    }
}
