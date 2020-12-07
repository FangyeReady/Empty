using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Test : MonoBehaviour
{
    public Transform vec1;
    public Transform vec2;


    private void Start() {

        Vector3 touying1 = Vector3.Project(vec1.position, vec2.position ); //求vec1在vec2上的投影向量

        float touying2 = Vector3.Dot(  vec1.position, vec2.position.normalized  );

        Debug.Log( "投影的长度：" +  touying1.magnitude + "-------" + touying2 );

        Debug.Log( "投影：" +  touying1.normalized + "-------" + vec2.position.normalized );


        Debug.Log("叉乘：" +  Vector3.Cross(vec1.position, vec2.position) );

    }
}
