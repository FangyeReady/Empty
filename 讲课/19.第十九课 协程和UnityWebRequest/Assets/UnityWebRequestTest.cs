using System;//Uri的命名空间
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;


[Serializable]
public class Npc
{
    public int Id;
    public string name;
    public float hp;
    public float atk;
    public float def;
}

[Serializable]
public class Npcs
{
    public Npc[] npcs;
}



/*九城教育*/
public class UnityWebRequestTest : MonoBehaviour
{
    private void Start()
    {
        // StartCoroutine( GetFile() );

        // StartCoroutine(GetData());


        // StartCoroutine(SendData());



        // StartCoroutine(GetHeader());


        StartCoroutine(GetTexture());


    }


    IEnumerator GetFile()
    {
        //构建路径
        string path = Path.Combine(Application.streamingAssetsPath, "data.txt");
        //构建Uri
        Uri uri = new Uri(path);
        //取得路径
        Debug.Log(uri.AbsoluteUri);

        //构建协议
        UnityWebRequest request = UnityWebRequest.Get(uri.AbsoluteUri);

        //发送协议
        yield return request.SendWebRequest();


        if (!request.isNetworkError && !request.isHttpError && request.isDone)
        {
            var text = request.downloadHandler.text; // 文本信息，使用UTF8编码解析
            var bytes = request.downloadHandler.data; // 字节数组

            Debug.Log("取得的数据:" + text);
        }
    }

    IEnumerator GetData()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "NpcData.txt");
        Uri uri = new Uri(path);

        Debug.Log(uri.AbsoluteUri);

        UnityWebRequest request = UnityWebRequest.Get(uri.AbsoluteUri);
        yield return request.SendWebRequest();


        if (request.isDone && !request.isNetworkError)
        {
            Debug.Log(request.downloadHandler.text);


            Npcs data = JsonUtility.FromJson<Npcs>(request.downloadHandler.text);

            Debug.Log("拿到数据类型: " + data.npcs[0].name);
        }
        else
        {
            Debug.LogError(request.error);
        }

    }

    IEnumerator SendData()
    {
        string path = "https://www.baidu.com/";

        //发送字符串协议
        //UnityWebRequest request = UnityWebRequest.Post(path, "asdasdasdasd");

        //发送表单
        WWWForm form = new WWWForm();
        form.AddBinaryData("name", Encoding.UTF8.GetBytes("方野"));
        form.AddBinaryData("sex", Encoding.UTF8.GetBytes("男"));

        UnityWebRequest request = UnityWebRequest.Post(path, form);

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (!request.isNetworkError && !request.isHttpError)
        {
            Debug.Log("状态码:" +  request.responseCode);
        }

    }


    IEnumerator GetHeader()
    {
        string path = "https://www.baidu.com/";

        UnityWebRequest request = UnityWebRequest.Head(path);
        yield return request.SendWebRequest();


        if (!request.isNetworkError && !request.isHttpError)
        {
            Dictionary<string,string> headers =  request.GetResponseHeaders();


            foreach (var item in headers)
            {
                Debug.Log(item.Key + "<------->" + item.Value);
            }
        }

    }



    IEnumerator GetTexture()
    {
        string url = "https://www.baidu.com/img/flexible/logo/pc/result.png";

        //用UnityWebRequestTexture从服务器获取图片
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();


        if (!request.isNetworkError && !request.isHttpError)
        {
            Debug.Log("状态码:" + request.responseCode);

            //取得下载的图片
            Texture2D tex = DownloadHandlerTexture.GetContent(request);


            string path = Path.Combine(Application.dataPath, "logo.png");
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                //将下载的图片转化为PNG格式
                byte[] datas = tex.EncodeToPNG();

                //保存到本地
                fs.Write(datas, 0, datas.Length);


                Debug.Log("写入图片成功~~!");
            }

        }

    }
}
