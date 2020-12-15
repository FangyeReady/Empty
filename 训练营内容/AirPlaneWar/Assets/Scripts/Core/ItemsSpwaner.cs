using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;
/*九城教育*/
public class ItemsSpwaner : MonoBehaviour
{
    GameObject bigBoomPrefab;


    private void Start()
    {
        bigBoomPrefab = Resources.Load<GameObject>("ItemBigBoom");


        StartCoroutine( SpwanBigBoom() );
    }


    IEnumerator SpwanBigBoom()
    {
        while (true)
        {
            yield return new WaitUntil(  () => { return GameManager.Instance.StartGame; } );

            Random.InitState((int)DateTime.Now.Ticks);
           

            int X = Random.Range(-19, 19);
            Instantiate(bigBoomPrefab, new Vector3(X, 0, 100), Quaternion.Euler(0, 180, 0));


            float waitTime = Random.Range(1, 10);

            //等待
            yield return new WaitForSeconds(waitTime);
        }
    }
}
