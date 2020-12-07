
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.XR.WSA.Input;
/*九城教育*/
public class CoTest : MonoBehaviour
{

    int val1 = 0;

    Coroutine co;

    private void Start()
    {
        //StartCoroutine(Test(1));
        //StartCoroutine(TestNull());

        //co = StartCoroutine(TestWaitUntil());


        StartCoroutine("TestWaitUntil");
    }


    private void Update()
    {
        Debug.Log("U庞大特!~~~");


        if (Input.GetKeyDown(KeyCode.A))
        {
            val1 = 1;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            val1 = 0;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            //StopCoroutine(co);

            //StopCoroutine("TestWaitUntil");

            StopAllCoroutines();
        }
    }

    IEnumerator Test(int a)
    {
        Debug.Log("开始执行协程~~~" + a);


        var wait = new WaitForSeconds(1f); 
        while ( a == 1)
        {
            yield return wait;
            Debug.Log("继续执行协程~~~" + a);
        }

        yield return new WaitForSeconds(1f);
    }


    IEnumerator TestNull()
    {
        Debug.Log("开始执行协程~~~");
        yield return null;
        while (true)
        {
            yield return null;


            yield return new WaitForEndOfFrame();

            yield return new WaitForSecondsRealtime(0.1f);

            yield return new WaitForFixedUpdate();

            Debug.Log("继续执行协程~~~");
        }  
    }


    IEnumerator TestWaitUntil()
    {
        Debug.Log("开始执行协程~~~" + val1);

        while (true)
        {

            yield return new WaitUntil(   () => { return val1 == 1; }   );
            Debug.Log("继续执行协程~~~TRUE" + val1);


            yield return new WaitWhile(() => { return val1 == 1; });
            Debug.Log("继续执行协程~~~FALSE:" + val1);


            yield break;
        }


        Debug.Log("协程结束~~!");

        yield return new WaitForSeconds(1f);
    }

}
