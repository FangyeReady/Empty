using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 3f;

    //玩家
    Transform player;

    //位置偏移量
    Vector3 offset;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //获取自己和玩家的位置差量
        offset = this.transform.position - player.position;
    }

    private void FixedUpdate()
    {
        //更新摄像机的位置  
        Vector3 targetPos = player.position + offset;

        //第一种跟随
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);


        //第二种跟随
        //transform.position = targetPos;
    }

}
