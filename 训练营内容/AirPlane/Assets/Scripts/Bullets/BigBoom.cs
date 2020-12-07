using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class BigBoom : MonoBehaviour
{
    //旋转的节点
    public Transform rotateRoot;
    //子弹发射点1
    public Transform point1;
    //子弹发射点2
    public Transform point2;

    //弹幕密集度
    public float fireRate = 0.04f;
    //弹幕持续时间
    public float destroyTime = 5f;

    //旋转的初始速度
    public float rotateSpeed = 200f;
    //旋转的加速度
    private float rotateAddtive = 4f;

    //移动速度
    private float moveSpeed = 30f;

    //子弹的资源
    GameObject bulletPrefab;

    private void Awake()
    {
        //一定时间后销毁
        Destroy(this.gameObject, destroyTime);
    }


    private void Start()
    {
        //把子弹加载到内存中
        bulletPrefab = Resources.Load<GameObject>("Bullet");

        //调用生成的子弹方法
        StartCoroutine( Fire() );
    }

    private void Update()
    {
        //开始旋转节点
        rotateRoot.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
        //旋转速度不断增加
        rotateSpeed += rotateAddtive;


        //如果炸弹位置小于0则移动
        if (transform.position.z  <= 2)
        {  
            //移动
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }


    IEnumerator Fire()
    {
        //循环生成
        while (true)
        {
            //生成子弹

            Instantiate(bulletPrefab, point1.position, point1.rotation);

            Instantiate(bulletPrefab, point2.position, point2.rotation);

            //等待0.04秒
            yield return new WaitForSeconds(fireRate);

        }
    }


  }
