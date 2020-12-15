using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PlayerFire : MonoBehaviour
{
    //开火的位置
    public Transform midFire;
    public Transform leftFire;
    public Transform rightFire;


    //子弹的预制
    GameObject bulletPrefab;
    //大炸弹的预制
    GameObject bigBoomPrefab;

    //大炸弹的数量
    public int BigBoomCount = 1;


    //攻击间隔
    public float fireInterval = 0.1f;
    float timer = 0f;

    //超级子弹的状态
    bool superFire = false;
    //超级子弹的时间
    float superFireTime = 0f;

    private void Start()
    {
        //加载资源
        bulletPrefab = Resources.Load<GameObject>("Bullet");
        
        bigBoomPrefab = Resources.Load<GameObject>("BigBoom");


        UIManager.Instance.UpdateBoom(BigBoomCount);
    }

    private void Update()
    {
        //如果未开始游戏
        if (GameManager.Instance.StartGame  == false)
        {
            return;//不走下面的逻辑
        }


        //按键触发大炸弹
        if (Input.GetKeyDown(KeyCode.Space)  && BigBoomCount > 0)
        {
            Instantiate(bigBoomPrefab, midFire.position, midFire.rotation);

            BigBoomCount = BigBoomCount - 1;

            UIManager.Instance.UpdateBoom(BigBoomCount);
        }





        //下面的时间控制子弹的发射

        timer = timer + Time.deltaTime;//Time.deltaTime:上一帧所花的时间

        //开启超级子弹
        if (timer >= fireInterval && superFire)
        {
            Instantiate(bulletPrefab, leftFire.position, leftFire.rotation);
            Instantiate(bulletPrefab, rightFire.position, rightFire.rotation);
        }

        if ( timer >= fireInterval )
        {
            timer = 0f;
            //实例化: 开火
            Instantiate(bulletPrefab, midFire.position, midFire.rotation);
        }



        //如果未开启超级子弹状态
        if (!superFire)
        {
            return;//代码在此处终结
        }
        //超级子弹时间递减
        superFireTime = superFireTime - Time.deltaTime;

        if (superFireTime <= 0f)
        {
            superFireTime = 0f;
            superFire = false;
        }

        UIManager.Instance.UpdateSuperTime(superFireTime);


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SuperBuff"))
        {
           superFire = true;

            superFireTime = other.GetComponent<ItemSuperBuff>().SuperTime;

            UIManager.Instance.UpdateSuperTime(superFireTime);

            Destroy(other.gameObject);
        }


        if (other.gameObject.CompareTag("BigBoom"))
        {
            int num = other.gameObject.GetComponent<ItemBigBoom>().addNum;

            //添加炸弹数量
            BigBoomCount = BigBoomCount + num;

            //限制大炸弹的数量
            if (BigBoomCount > GameManager.Instance.MaxBoomCount)
            {
                BigBoomCount = GameManager.Instance.MaxBoomCount;
            }
            Destroy(other.gameObject);

            UIManager.Instance.UpdateBoom(BigBoomCount);
        }
    }


}
