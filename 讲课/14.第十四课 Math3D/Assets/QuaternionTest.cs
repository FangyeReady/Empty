using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class QuaternionTest : MonoBehaviour
{
    float angle = 45f;

    Quaternion targetRotation;


    public Transform cube2;

    private void Awake()
    {
        //返回四元数对应的欧拉角
        Vector3 eulerRotation = transform.rotation.eulerAngles;

        Debug.Log(eulerRotation);

        Debug.Log(Quaternion.identity);



        //GameObject.Instantiate(gameObject, Vector3.zero, Quaternion.identity);    

        float angle =  Quaternion.Angle(transform.rotation, Quaternion.Euler(0, 90, 0)); //Vector3.Angle()

        Debug.Log("夹角:" + angle);


        targetRotation = Quaternion.Euler(0, 90, 0);

    }




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, angle, 0);
            angle += 45;
        }

        //围绕某个轴旋转
        //transform.rotation = Quaternion.AngleAxis(angle++, new Vector3(1,1,0));

        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);


        //匀速旋转
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1);



        Quaternion qua = Quaternion.LookRotation(cube2.position - transform.position);



        transform.rotation = Quaternion.Lerp(transform.rotation, qua, Time.deltaTime);
    }
}
