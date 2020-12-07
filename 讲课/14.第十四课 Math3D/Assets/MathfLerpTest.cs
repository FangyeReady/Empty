using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class MathfLerpTest : MonoBehaviour
{
    float curValue = 0f;
    float targetValue = 1f;

    MeshRenderer msh;

    float R;

    public bool isTime = false;

    private void Awake()
    {
        msh = GetComponent<MeshRenderer>();
        R = msh.material.color.r;

        Debug.Log("----------------插值结果----------------");
        Debug.Log(Mathf.Lerp(0, 100, 0));
        Debug.Log(Mathf.Lerp(0, 100, 0.1f));
        Debug.Log(Mathf.Lerp(0, 100, 0.2f));
        Debug.Log(Mathf.Lerp(0, 100, 0.3f));
        Debug.Log(Mathf.Lerp(0, 100, 0.4f));
        Debug.Log(Mathf.Lerp(0, 100, 0.5f));
        Debug.Log(Mathf.Lerp(0, 100, 0.6f));
        Debug.Log(Mathf.Lerp(0, 100, 0.7f));
        Debug.Log(Mathf.Lerp(0, 100, 0.8f));
        Debug.Log(Mathf.Lerp(0, 100, 0.9f));
        Debug.Log(Mathf.Lerp(0, 100, 1f));
        Debug.Log("----------------------------------------");

        Debug.Log("----------------插值结果----------------");
        Debug.Log(Mathf.Lerp(90, 100, 0));
        Debug.Log(Mathf.Lerp(90, 100, 0.1f));
        Debug.Log(Mathf.Lerp(90, 100, 0.2f));
        Debug.Log(Mathf.Lerp(90, 100, 0.3f));
        Debug.Log(Mathf.Lerp(90, 100, 0.4f));
        Debug.Log(Mathf.Lerp(90, 100, 0.5f));
        Debug.Log(Mathf.Lerp(90, 100, 0.6f));
        Debug.Log(Mathf.Lerp(90, 100, 0.7f));
        Debug.Log(Mathf.Lerp(90, 100, 0.8f));
        Debug.Log(Mathf.Lerp(90, 100, 0.9f));
        Debug.Log(Mathf.Lerp(90, 100, 1f));
        Debug.Log("----------------------------------------");



    }





    private void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, new Vector3(curValue, 3.85f, 0), Time.deltaTime );

        // curValue = Mathf.Lerp(curValue, targetValue, 0.1f);

        // transform.position = Vector3.left * curValue;

        if (Input.GetKey(KeyCode.A))
        {
            if (isTime)
            {
                curValue = Mathf.Lerp(curValue, targetValue, Time.deltaTime);
            }
            else 
            {
                curValue = Mathf.Lerp(curValue, targetValue, 0.02f);         
            }
        }

      



        msh.material.color = new Color(R + curValue, msh.material.color.g, msh.material.color.b);

        
    }

    private void LateUpdate()
    {
        
    }

}
