using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Networking;

[System.Serializable]
public class Npc
{
    public int Id;
    public string 名称;
    public float 血量;
    public float 攻击力;
    public float 防御力;
}

public class Npcs
{
    public Npc[] npcs;
}

//[ExecuteInEditMode]
public class TestApp : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
       // StartCoroutine("ReadTxt");


        Application.wantsToQuit += () => { Debug.Log("即将退出游戏"); return true; };

        Coroutine cour = StartCoroutine(Test(1));

        StartCoroutine(UnityWebRequest_Test());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Application.CaptureScreenshot(Path.Combine(Application.dataPath, "tex"));
            //ScreenCapture.CaptureScreenshot(Path.Combine(Application.dataPath, "tex.png"));

            Application.Quit();

            Debug.Log("点击退出~");
        }
    }

    IEnumerator ReadTxt()
    {
        //得到本地资源路径
        string path = Path.Combine(Application.streamingAssetsPath, "test1.txt");
        //创建统一资源标识符（uri）
        System.Uri uri = new System.Uri(path);
        //创建一个请求,  AbsoluteUri绝对路径:file:///D:/UnityProject/Application/Assets/StreamingAssets/test1.txt
        UnityWebRequest request = UnityWebRequest.Get(uri.AbsoluteUri);
        Debug.Log(uri.AbsoluteUri);
        //挂起，读取成功后才往下走
        yield return request.SendWebRequest();
        //如果完成了,并没有任何错误
        if (request.isDone && !request.isHttpError)
        {
            //Debug.Log("得到数据：  " + request.downloadHandler.text); 
            var jsonStr = request.downloadHandler.text;
            Debug.Log(jsonStr);
            var npcs = JsonUtility.FromJson<Npcs>(jsonStr);
            Debug.Log(npcs.npcs.Length);
        }

        Debug.Log(request.uploadHandler);
        
            
    }


    IEnumerator Test(int a)
    {
        Debug.Log("开始执行代码    " + a);
        yield return new WaitForSeconds(1f);
        yield break;
        Debug.Log("继续执行代码");
    }


    IEnumerator UnityWebRequest_Test() 
    { 
        UnityWebRequest uwq = UnityWebRequest.Get("http://www.baidu.com"); 
        yield return uwq.SendWebRequest(); 

        if (string.IsNullOrEmpty(uwq.error))//如果错误消息为空 
        { 
            print("Success:  " + uwq.downloadHandler.text); 
        } 
        else 
        { 
            print("Error:  " + uwq.error); 
        } 
    }
}
