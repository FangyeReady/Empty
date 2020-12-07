using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class FadeInAndOut : MonoBehaviour
{
    Material mat;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;


        StartCoroutine(Fade());
    }


    IEnumerator Fade()
    {

        float rate = 0.0f;
        float alpha = 0.0f;
        while (true)
        {
            alpha = Mathf.PingPong(rate, 1f);
            rate += 0.03f;

            mat.color = new Color(1f, 1f, 1f, alpha);

            yield return null;//new WaitForSeconds(0.02f);
        }
    }

}
