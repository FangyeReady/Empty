using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class MatUVMove : MonoBehaviour
{
    //材质球
    Material mat;
    //偏移量
    float offset = 0f;

    private void Start()
    {
        //取得材质球
        mat = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if (mat != null)
        {
            //改变偏移量的值
            offset -= Time.deltaTime * 0.05f;
            //将偏移量赋值给材质球对应的值
            mat.mainTextureOffset = new Vector2(0f, offset);
        }
    }
}
