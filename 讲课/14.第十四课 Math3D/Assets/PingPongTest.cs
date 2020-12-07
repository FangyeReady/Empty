using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PingPongTest : MonoBehaviour
{
    public float rate;

    [Range(0f,1f)]
    public float addRate = 0.05f;
    private void Update()
    {
        float curVal = Mathf.PingPong(rate, 5);

        rate += addRate;

        transform.position = Vector3.left * curVal;
    }
}
