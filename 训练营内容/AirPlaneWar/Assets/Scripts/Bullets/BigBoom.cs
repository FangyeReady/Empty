using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class BigBoom : MonoBehaviour
{
    //持续时间
    public float holdTime = 5f;

    //炸弹的子弹
    public GameObject bulletPrefab;

    //旋转的节点
    public Transform rotateRoot;


    public Transform point1;
    public Transform point2;


    //旋转速度
    public float rotateSpeed = 180f;
    //移动速度
    public float moveSpeed = 10f;

    float timer = 0f;
    float fireInterval = 0.05f;

    private void Awake()
    {
        Destroy(this.gameObject, holdTime);

        timer = fireInterval;
    }



    private void Update()
    {
        //旋转
        rotateRoot.Rotate( Vector3.up * Time.deltaTime * rotateSpeed, Space.World );
        //移动
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);




        timer = timer + Time.deltaTime;//Time.deltaTime:上一帧所花的时间

        //开启超级子弹
        if (timer >= fireInterval)
        {
            timer = 0f;
            Instantiate(bulletPrefab, point1.position, point1.rotation);
            Instantiate(bulletPrefab, point2.position, point2.rotation);
        }

    }




}
