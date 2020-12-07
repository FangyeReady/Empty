using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTransform : MonoBehaviour
{
    public Vector3 targetScale;

    public float rate;

    private float intervalTime = 0.04f;


    private void Start()
    {
        StartCoroutine(Scale());
    }


    IEnumerator Scale()
    {

        while (true)
        {
            float x = Mathf.PingPong(rate, targetScale.x) + 0.7f;
            float y = Mathf.PingPong(rate, targetScale.y) + 0.7f;
            float z = Mathf.PingPong(rate, targetScale.z) + 0.7f;
            rate += 0.01f;


            transform.localScale = new Vector3(x, y, z);

            yield return new WaitForSeconds(0.04f);
        }
    }
}
