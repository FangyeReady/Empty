using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{

    Rigidbody rig;
    public float force = 10;
    public GameObject Birth_pos;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        Birth_pos = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (float.Parse(string.Format("{0:F1}",transform.position.y))>3f)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.rotation = Birth_pos.transform.rotation;
            rig.velocity += Vector3.up * force;
            transform.position = Birth_pos.transform.position - Vector3.up *2f + Birth_pos.transform.forward * 15f;
        }
    }
}
