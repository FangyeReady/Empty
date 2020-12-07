using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Move : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x <= 0)
        {
            transform.Translate( Vector3.right * 2 * Time.deltaTime);
        }

    }
}
