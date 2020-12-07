using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class TransTest : MonoBehaviour
{
    /// <summary>
    /// 假设为对方的组件
    /// </summary>
    CubeTest cbTest;

    private void Start()
    {
        //this.transform;//表示自己的Transform

        //cbTest.transform;//表示对方的Transform
        //cbTest.GetComponent<Transform>();

        //transform.position = new Vector3(1, 2, 3);
        //transform.rotation = Quaternion.Euler(90, 0, 10);
        //transform.localScale = new Vector3(0.5f, 1, 1);

        //transform.localPosition = new Vector3(4, 5, 6);
        //transform.localRotation = Quaternion.Euler(15, 20, 35);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // this.transform.Rotate(new Vector3(45, 0, 0));


            // this.transform.Rotate(Vector3.forward, 30);

            // this.transform.Rotate(Vector3.up, 45);

            //用欧拉角旋转
            transform.localEulerAngles = new Vector3(45, 0, 0);

            Debug.Log(transform.root.name);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            this.transform.localScale = new Vector3(0.5f, 0.7F, 0.3F);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject camera = GameObject.Find("Main Camera");
            //this.transform.parent = camera.transform;
            this.transform.SetParent(camera.transform);
        }


    }
}
