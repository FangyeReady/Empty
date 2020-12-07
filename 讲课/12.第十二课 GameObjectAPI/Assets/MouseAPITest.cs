using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class MouseAPITest : MonoBehaviour
{
    private void Update()
    {
        //0左键 1右键 2中键 
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("点击了鼠标左键");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("点击了鼠标右键");
        }

        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("点击了鼠标中键");
        }

        //Debug.Log(Input.mousePosition);


        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("按住了A");
        }

        if (Input.GetKey("a"))
        {
            Debug.Log("按住了a");
        }



        if (Input.GetButton("Fire1"))
        {
            Debug.Log("按下了Fire1");
        }


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Debug.Log("水平:" + h + "   竖直:" + v);
    }
}
