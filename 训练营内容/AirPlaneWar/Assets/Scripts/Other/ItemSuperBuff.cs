using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class ItemSuperBuff : MonoBehaviour
{
    public float holdTime = 5f;

    public float SuperTime = 10f;

    private void Awake()
    {
        Destroy(this.gameObject, holdTime);
    }
}
