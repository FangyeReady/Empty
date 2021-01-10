using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position +=  transform.right * Time.deltaTime * 2;

         //transform.Translate(Vector3.right * Time.deltaTime * 2f);

         Debug.Log(transform.right);
    }
}
