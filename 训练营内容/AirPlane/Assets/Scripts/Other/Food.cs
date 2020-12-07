using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Food : MonoBehaviour
{
    //销毁时间
    public float destroyTime = 15f;
    private void Awake()
    {
        //N秒后销毁该对象                      秒
        Destroy(this.gameObject, destroyTime);
    }
}
