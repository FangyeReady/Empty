using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*九城教育*/
public class GameObjectSpwaner : MonoBehaviour
{
    public GameObject cubePrefab;
    GameObject obj;


    public GameObject cube2;

    private void Awake()
    {
        //加载场景时不销毁
        GameObject.DontDestroyOnLoad(this.gameObject);



        Debug.Log("自己是否激活activeSelf:" + cube2.activeSelf + "    层级是否激活:" + cube2.activeInHierarchy);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //实例化
            obj = Instantiate(cubePrefab);
            obj.name = "我是Cube克隆体";
            obj.AddComponent<Cube>();
           
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            //销毁
            GameObject.Destroy(obj);
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            //加载场景
            SceneManager.LoadScene(1);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
           //查找
           GameObject camera = GameObject.Find("Main Camera");
           camera.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //按照tag查找游戏物体
            GameObject camera =  GameObject.FindGameObjectWithTag("MainCamera");
            //camera.SetActive(false);
            //查找复数形式
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < players.Length; i++)
            {
                players[i].SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //根据类型查找
            Cube cb = GameObject.FindObjectOfType<Cube>();
            cb.gameObject.SetActive(false);


            BoxCollider[] cbS = GameObject.FindObjectsOfType<BoxCollider>();
        }


    }
}
