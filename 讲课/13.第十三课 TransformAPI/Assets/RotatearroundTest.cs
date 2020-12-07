using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class RotatearroundTest : MonoBehaviour
{
    public Transform sun;

    private void Awake()
    {
       // Destroy(this.gameObject, 10f);
    }


    private void Update()
    {
        transform.RotateAround(sun.position, Vector3.up, Time.deltaTime * 50);
        Debug.Log("Update~");

        if (Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale = 0.5f;
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            Time.timeScale = 5f;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Time.timeScale = (int)Time.timeScale == 0 ? 1 : 0;
        }

    }


    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate~");
    }
}
