using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*九城教育*/
public class OnMouseButtonTest : MonoBehaviour
{

    float curZ = 0.0f;
    bool isDrag = false;

    Vector3 prePos;

    private void Update()
    {
        if (isDrag)
        {
            Vector3 curScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);
            Vector3 curWorldPos = Camera.main.ScreenToWorldPoint(curScreenPos);

            transform.position = curWorldPos;

            print(curWorldPos + "----" + curScreenPos);
        }


        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
            transform.position = prePos;
        }
    }

    private void OnMouseDown()//当鼠标按下 
    {
        //Debug.Log("当鼠标按下");

        prePos = transform.position;
    }
    private void OnMouseUp()//当鼠标抬起 
    {
        //Debug.Log("当鼠标抬起");

    }
    private void OnMouseUpAsButton()//当鼠标在同一个物体按下后抬起  
    {
        //Debug.Log("当鼠标在同一个物体按下后抬起");
    }
    private void OnMouseEnter()//当鼠标进入
    {
        //Debug.Log("当鼠标进入");
    }

    private void OnMouseOver()//当鼠标停留
    {
        //Debug.Log("当鼠标停留");
    }
    private void OnMouseExit()//当鼠标退出
    {
        //Debug.Log("当鼠标退出");
    }
    private void OnMouseDrag()//当鼠标拖拽
    {
        Debug.Log("当鼠标拖拽");



        isDrag = true;
        var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.x, 0.5f);
        var pos = Camera.main.ScreenToWorldPoint(mousePos);

        //print(pos + "----" + Input.mousePosition);
        
    }



}
