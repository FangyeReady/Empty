using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class SpwanPoint : MonoBehaviour
{
    private void Awake()
    {
        //获取子物体数量
        //Debug.Log(this.transform.childCount);

        //Debug.Log("Right : " + this.transform.right);
        //Debug.Log("Forward : " + this.transform.forward);
        //Debug.Log("Up : " + this.transform.up);
    }


    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            //print(child.name);
           //Destroy(child.gameObject);
        }


        Transform trans =  transform.Find("Cube1");
        // trans.gameObject.SetActive(false);



        Child ch = transform.GetComponentInChildren<Child>();
        ///ch.Print();

        //Child此处会包含父物体的对象, 因为父物体也有Child组件, 因此如果想只操作子物体的话,应该从
        //下标为1开始
        Child[] chs = transform.GetComponentsInChildren<Child>();

        for (int i = 0; i < chs.Length; i++)
        {
            chs[i].Print();
        }

    }
}
