using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class EnemyMoveController : MonoBehaviour
{
    public float speed = 10f;
    private void Update()
    {
        //移动
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
