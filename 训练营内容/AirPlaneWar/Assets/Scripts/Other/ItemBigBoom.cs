using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class ItemBigBoom : MonoBehaviour
{
    public int addNum = 1;

    public float holdTime = 60f;

    public float speed = 7f;

    private void Awake()
    {
        Destroy(this.gameObject, holdTime);
    }


    private void Update()
    {
        //朝前移动
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
