using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PlayerFireController : MonoBehaviour
{

    //得到子弹发射的中间位置
    public Transform midPoint;

    public Transform leftPoint;

    public Transform rightPoint;

    //用于控制是否全力输出
    bool isAllFire = false;

    //全力输出的时间
    float superFireTime = 0f;

    //攻击间隔
    float fireInterval = 0.2f;
    //计时
    float timeLast = 0f;


    //声明一个未赋值变量
    GameObject bulletPrefab;

    //声明一个未赋值的大炸弹
    GameObject bigboomPrefab;

    private void Start()
    {
        //赋值变量
        bulletPrefab = Resources.Load<GameObject>("Bullet");
        //赋值
        bigboomPrefab = Resources.Load<GameObject>("BigBoom");
    }

    private void Update()
    {
        //如果未开始游戏,就无法移动
        if (GameManager.Instance.IsStartGame() == false)
        {
            return;
        }


        timeLast += Time.deltaTime;
        if (timeLast >= fireInterval)
        {
            timeLast = 0f;
            //按空格键发射子弹
            //if (Input.GetKeyDown(KeyCode.Space))
            {
                //生产出一个子弹
                Instantiate(bulletPrefab, midPoint.position, midPoint.rotation);
                //全力输出模式
                if (isAllFire == true)
                {
                    Instantiate(bulletPrefab, leftPoint.position, leftPoint.rotation);
                    Instantiate(bulletPrefab, rightPoint.position, rightPoint.rotation);
                }
            }
        }

       
        //释放大招
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //得到当前炸弹数量
            int boomCount = GameManager.Instance.BoomCount;
            //如果数量足够
            if (boomCount > 0)
            {
                //生产出一个炸弹
                Instantiate(bigboomPrefab, midPoint.position, midPoint.rotation);

                //炸弹数量减少一个
                boomCount -= 1;

                //同步数据
                GameManager.Instance.BoomCount = boomCount;
            }        
        }

        //如果未开启全力输出, 则不进行计时
        if (isAllFire == false)
        {
            return;
        }

        //当正在全力输出时, 计时开始
        superFireTime -= Time.deltaTime;  
       
        //当全力输出时间小于等于0时, 结束全力开火
        if (superFireTime <= 0 )
        {
            isAllFire = false;
            superFireTime = 0f;
        }

        UIManager.Instance.UpdateSuperTime(superFireTime);

    }
    //触发
    private void OnTriggerEnter(Collider other)
    {
        //触发了火力子弹
        if (other.gameObject.CompareTag("FireFood"))
        {
            //重置全力开火的时间
            superFireTime = 5f;
            UIManager.Instance.UpdateSuperTime(superFireTime);
            //设置进入全力输出模式
            isAllFire = true;

            //销毁
            Destroy(other.gameObject);
        }
    }

}
