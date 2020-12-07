using System.Collections.Generic;
using System.Data;
using UnityEngine;
/*九城教育*/
public class SetSublingTest : MonoBehaviour
{
    int index = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.SetAsFirstSibling();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            this.transform.SetAsLastSibling();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            this.transform.SetSiblingIndex(index++);
        }

    }
}
