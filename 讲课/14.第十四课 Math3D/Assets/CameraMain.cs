using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class CameraMain : MonoBehaviour
{
    Vector3 screenSpace;

    Vector3 offset;

    private void OnMouseDown()
    {
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 curMouserPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

        Vector3 curMouserPosInWorld = Camera.main.ScreenToWorldPoint(curMouserPos);

        offset = transform.position - curMouserPosInWorld;
    }



    private void OnMouseDrag()
    {
        Vector3 curMouserPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

        Vector3 curMouserPosInWorld = Camera.main.ScreenToWorldPoint(curMouserPos);

        transform.position = curMouserPosInWorld + offset;
    }
}
