using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Speed : MonoBehaviour
{
    public Rigidbody rig;
    int Force = 300;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rig.AddRelativeForce(Vector3.forward * Force, ForceMode.Force);


    }


    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.forward * Time.deltaTime * 100);
    }

}
