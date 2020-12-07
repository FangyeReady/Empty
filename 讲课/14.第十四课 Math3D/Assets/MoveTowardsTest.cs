using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class MoveTowardsTest : MonoBehaviour
{
    float target = 5f;
    private void Update()
    {
        //匀速运动
        float curX = Mathf.MoveTowards(transform.position.x, target, 0.1f);

        if (curX == 5f)
        {
           target = 10f;
        }


        transform.position = new Vector3(curX, transform.position.y, transform.position.z);

        //transform.position.x = 1;//值类型的返回值, 修改并不会影响到源来的数据, 因此被禁用
    }
}
