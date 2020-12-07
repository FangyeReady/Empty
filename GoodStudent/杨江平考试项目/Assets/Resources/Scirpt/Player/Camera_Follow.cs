using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    GameObject player;
    float speed =10;
    public float moveSpeed;
    Vector3 angle = Vector3.zero;
//    float time = 0.2f;
//    float timeGo = 0f;
//      想弄一个鼠标几秒没动了 如何才插值看向角色，免得动鼠标的时候也在插值转动，就很恼火，如何没实现，逻辑没对，
//      今天学了 协程应该可以实现这个，而且应该会很容易，敌人生产的时候已经加了协程了，有的功能想法没实现，所以就没有优化这个了
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Person");
        moveSpeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4f;
        }
        else
        {
            speed = 2f;
        }
        angle.x = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;
        angle.y = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
        transform.localEulerAngles = angle;
        Vector3 Dis = player.transform.position + Vector3.up * 6f - player.transform.forward * 10f;
        transform.position = Vector3.Lerp(transform.position, Dis, Time.deltaTime * speed);
/*        if (stopmouse())
        {
        timeGo += Time.deltaTime;*/
/*        if (timeGo > time)
        {*/
         Vector3 Look = player.transform.position - transform.position;
         Quaternion A = Quaternion.LookRotation(Look);
         transform.rotation = Quaternion.Lerp(transform.rotation, A, Time.deltaTime * speed);
/*            timeGo = 0f;
        }
        }*/
    }
/*    public bool stopmouse()
    {
        if (Input.mousePosition==angle)
        {
            Debug.LogError("asd");
            return true;
        }
        else
        {
            return false;
        }
        
    }*/
}
