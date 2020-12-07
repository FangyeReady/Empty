using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBOX : MonoBehaviour
{
    GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.transform.position);    
    }
}
