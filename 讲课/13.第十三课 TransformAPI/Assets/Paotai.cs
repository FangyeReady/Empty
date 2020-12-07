using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Paotai : MonoBehaviour
{
    public Transform target;


    private void Start()
    {
        transform.LookAt(new Vector3(0,0,0));
    }

    private void Update()
    {
        //transform.LookAt(target, Vector3.up);
    }
}
