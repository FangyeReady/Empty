using System;
using UnityEngine;
using Random = UnityEngine.Random;

/*九城教育*/
public class Stone : MonoBehaviour
{
    private int speed = 0;

    //生命值
    public int health = 3;
    //死亡特效
    GameObject effPrefab;

    private void Awake()
    {
        //N秒后销毁子弹
        Destroy(this.gameObject, 25f);

        //随机设置速度
        Random.InitState((int)DateTime.Now.Ticks);
        speed = Random.Range(5, 30);

        //生成随机数
        float x = Random.Range(25f, 50f);
        float y = Random.Range(25f, 50f);
        float z = Random.Range(25f, 50f);
        //设置随机缩放
        transform.localScale = new Vector3(x, y, z);
    }


    private void Start()
    {
        //加载死亡特效到内存
        effPrefab = Resources.Load<GameObject>("EnemyDieEff");
    }

    private void Update()
    {
        //移动
        transform.Translate( Vector3.forward * Time.deltaTime * speed );
    }

    private void OnTriggerEnter(Collider other)
    {
        //如果碰到了子弹，销毁子弹
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            //销毁对方
            Destroy(other.gameObject);
            //生命值减少1
            health -= 1;
            if (health <= 0 )
            {
                UIManager.Instance.UpdateScore(30);
                //销毁自己
                Destroy(this.gameObject);
            }  
        }
    }

    //当对象被销毁时，调用
    private void OnDestroy()
    {
        Instantiate(effPrefab, this.transform.position, this.transform.rotation);
    }

}
