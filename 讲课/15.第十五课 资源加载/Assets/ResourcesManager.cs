using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class ResourcesManager : MonoBehaviour
{
    public GameObject cubePrefab1;


    public GameObject cubePrefab2;

    ResourceRequest request;

    Texture stone;


    private void Start()
    {
        // Instantiate(cubePrefab1);

        //Debug.Log("");  
    }



    private void Update()
    {
        //指定加载某一个资源
        if (Input.GetKeyDown(KeyCode.A))
        {
            //需要强转
            GameObject cube = Resources.Load("Cube1") as GameObject;
            if (cube != null)
            {
                var item1 = Instantiate(cube);
                item1.name = "需要强转";
            }

            //不需要转换
            cubePrefab2 = Resources.Load<GameObject>("Cube1");
            var item2 = Instantiate(cubePrefab2);
            item2.name = "不需要";
        }




        if (Input.GetKeyDown(KeyCode.B))
        {
            //如果传入的资源名称,则加载所有Resources文件下的同名资源
            //GameObject[] objects =  Resources.LoadAll<GameObject>("Cube1");

            //如果传入的是文件夹名称, 则加载所有该文件夹下的资源
            GameObject[] objects = Resources.LoadAll<GameObject>("New");


            for (int i = 0; i < objects.Length; i++)
            {
                var item =  Instantiate(objects[i]);
                item.transform.position = Vector3.left * i;
                item.name = i.ToString();
            }
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(LoadAsync("Cube1"));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            var cube  = Resources.Load<GameObject>("New2/Cube2");
            stone = Resources.Load<Texture>("New2/Stone");


            GameObject item = Instantiate(cube);
            item.GetComponent<MeshRenderer>().material.mainTexture = stone;
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            //从内存卸载指定资源
            Resources.UnloadAsset(stone);

            //从内存卸载所有未使用的资源
            Resources.UnloadUnusedAssets();
        }





        if (request != null)
        {
            Debug.Log( "加载进度:"  + request.progress);
        }
    }




    IEnumerator LoadAsync(string path)
    {
        request =  Resources.LoadAsync<GameObject>(path);
        yield return request;

        if (request.isDone)
        {
            Instantiate(request.asset);
        }
    }

}
