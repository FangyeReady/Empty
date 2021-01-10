using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDir : MonoBehaviour
{
    public Space space;
    // Start is called before the first frame update
    void Start()
    {
        space = Space.World;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100 * Input.GetAxis("Mouse X"), space);

        //transform.Rotate(Vector3.left * Time.deltaTime * 100 * Input.GetAxis("Mouse Y"), Space.Self);

       
    }


}
