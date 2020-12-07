using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class AddForceUp : MonoBehaviour
{
    Rigidbody rid;
    private void Awake()
    {
        rid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
         rid.AddForce(Vector3.up * 10, ForceMode.Acceleration);

        // rid.AddForce(Vector3.up * 25, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.A))
        {
            rid.AddForce(Vector3.up * 25, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            rid.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
        }

        Debug.Log(rid.velocity);
    }
}
