using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*九城教育*/
public class PlayerMovement : MonoBehaviour
{
    //速度
    public float speed = 3;

    /// <summary>
    ///对象被创建时调用一次
    /// </summary>
    private void Start()
    {
        
    }

    /// <summary>
    /// 每帧调用
    /// </summary>
    private void Update()
    {
        //如果未开始游戏
        if (GameManager.Instance.StartGame == false)
        {
            return;//不走下面的逻辑
        }


        //得到水平变化量
        float h = Input.GetAxis("Horizontal");
        //得到垂直变化量
        float v = Input.GetAxis("Vertical");

        //Debug.Log("水平移动:" + h);

        //左边边界
        if (transform.position.x <= -19 &&  h < 0)
        {
            h = 0;
        }
        //右边边界
        if (transform.position.x >= 19 && h > 0)
        {
            h = 0;
        }

        //上边边界
        if (transform.position.z >= 70 && v > 0)
        {
            v = 0;
        }
        //下边边界
        if (transform.position.z <= 0 && v < 0)
        {
            v = 0;
        }




        //得到移动方向
        Vector3 dir = new Vector3(h, 0, v);
        //得到移动量
        Vector3 movement = dir * speed * Time.deltaTime;
        //移动
        transform.Translate(movement);
    }

}
