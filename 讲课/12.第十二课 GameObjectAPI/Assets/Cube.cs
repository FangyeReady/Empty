using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Cube : MonoBehaviour
{
    private void Start()
    {
        // this.gameObject;


        Debug.Log(this.gameObject.name + "-----" + this.tag + "-----" + this.transform);

        Debug.Log("是否激活:" + this.gameObject.activeSelf);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject cub2 = GameObject.Find("Cube (2)");


            Transform trans = cub2.GetComponent<Transform>();
            trans.position = Vector3.one;
        }


        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
    }
}
