using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Rotate : MonoBehaviour
{
    public bool IsRotateSelf = false;
    public bool IsRotateArround = false;

    public float selfSpeed = 0f;
    public float arroundSpeed = 0f;

    public Transform target;


    private void Update()
    {
        if (IsRotateSelf)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * selfSpeed);
        }


        if (IsRotateArround && target != null)
        {
            transform.RotateAround(target.position, Vector3.up, Time.deltaTime * arroundSpeed);
        }
    }

}
