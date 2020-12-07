using System;
using System.Collections.Generic;
using UnityEngine;


using Random = UnityEngine.Random;

/*九城教育*/
public class RandomTest : MonoBehaviour
{
    public GameObject cubePrefab;


    private void Start()
    {
        Random.InitState( (int)DateTime.Now.Ticks );


        for (int i = 0; i < 10; i++)
        {
            Debug.Log(Random.value);
        }


        transform.rotation = Random.rotation;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int rd = Random.Range(0, 10);
            Debug.Log(rd);
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
           Color cl = new Color(Random.value, Random.value, Random.value);


           Color color =  Random.ColorHSV();

           GetComponent<MeshRenderer>().material.color = cl;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            for (int i = 0; i < 10000; i++)
            {
                GameObject item = Instantiate(cubePrefab);

                Vector3 pos =  Random.insideUnitCircle * 100;


                item.transform.position = pos;
            }
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = 0; i < 1000; i++)
            {
                GameObject item = Instantiate(cubePrefab);

                Vector3 pos = Random.insideUnitSphere * 100;


                item.transform.position = pos;
            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < 10000; i++)
            {
                GameObject item = Instantiate(cubePrefab);

                Vector3 pos = Random.onUnitSphere * 100;


                item.transform.position = pos;
            }
        }

    }
}
