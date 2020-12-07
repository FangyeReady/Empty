using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class MovePingPong : MonoBehaviour
{
    float rate = 0f;


    Vector3 pos;

    private void Awake()
    {
        pos = transform.position;
    }

    private void Update()
    {
        float pingPong = Mathf.PingPong(rate, 10f);
        rate += 0.2f;


        transform.position = pos + Vector3.right * pingPong;


    

    }
}
