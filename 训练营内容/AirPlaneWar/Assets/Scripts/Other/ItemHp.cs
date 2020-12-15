using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class ItemHp : MonoBehaviour
{
    public float addHp = 1;

    public float holdTime = 5f;

    private void Awake()
    {
        Destroy(this.gameObject, holdTime);
    }
}
