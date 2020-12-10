using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class EnemyMovement : MonoBehaviour
{

    public float speed = 10f;

    private void Update()
    {
        //朝前移动
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
