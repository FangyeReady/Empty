using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaTest : MonoBehaviour
{
    public Transform vec1;
    public Transform vec2;


    float rotate = 0f;

    float angle;

    private void Start()
    {
        //指定每个轴的旋转度数
        //transform.rotation = Quaternion.Euler(45, 90, 45);


        //angle = Quaternion.Angle(vec1.rotation, vec2.rotation);

        //Vector3.Angle()


        //Up表示本地Y轴的朝向，当Up为Vector3.up时， 与本地Y轴重合
        //transform.rotation = Quaternion.LookRotation(vec1.position - transform.position, new Vector3(1, 2f, 1));
    }


    private void Update()
    {

        //绕着某个轴旋转
        //rotate += Time.deltaTime * 100;
        //transform.rotation = Quaternion.AngleAxis(rotate, Vector3.up);

        //插值转向
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45, 0), Time.deltaTime);


        //匀速转向
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 45, 0), 1);






        //不局限于val1, val2， t可以大于1
        //rotate = Mathf.LerpUnclamped(rotate, 100, 3);
        //print(rotate);

    }
}
