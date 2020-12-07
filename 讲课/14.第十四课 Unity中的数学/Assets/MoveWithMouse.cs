using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{

    Vector3 offset;
    Vector3 transformInScree;


    private void OnMouseDown()
    {
        //得到对象的屏幕坐标，获取这个对象相对屏幕的深度值Z
        transformInScree = Camera.main.WorldToScreenPoint(transform.position);

        //将此刻鼠标坐标转化为世界坐标, 利用这个屏幕深度值
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transformInScree.z));

        //鼠标和对象位置的差量
        offset = transform.position - mouseInWorld;

        print("深度值：" + transformInScree.z);
    }

    private void OnMouseDrag()
    {
        //此时鼠标的屏幕坐标（利用该物体的屏幕深度值）
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transformInScree.z);
        //将此刻鼠标坐标转化为世界坐标
        Vector3 curPoint = Camera.main.ScreenToWorldPoint(mousePos);
        //鼠标此时的位置， 加上差量就应该是对象的位置
        Vector3 targetPos = curPoint + offset;

        
        transform.position = targetPos;
    }

}
