using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Vector3Test : MonoBehaviour
{
    public Transform cube1;

    public Transform cube2;



    private void Start()
    {
        Vector3 dir = cube1.position - cube2.position;


        Debug.Log("长度:" + dir.magnitude);// Vector3.Magnitude()

        Debug.Log("长度的平方:" + dir.sqrMagnitude);// Vector3.SqrMagnitude()

        Debug.Log("标准化后的向量:" + dir.normalized );//Vector3.Normalize()


        //求cube1在cube2上的投影
        Vector3 project =  Vector3.Project(cube1.position, cube2.position);


        Debug.Log("cube1在cube2上的投影:" + project + "   投影向量单位化:" + project.normalized);

        Debug.Log("cube2的Vec: " + cube2.position.normalized);


        
    }
}
