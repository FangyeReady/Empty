using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using UnityEngine.Networking;

public class Request : MonoBehaviour
{
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(GetFile());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(SendFile());
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(RequestTexture());
        }
    }


    IEnumerator GetFile()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "data.txt");
        Uri uri = new Uri(path);

        Debug.Log(uri.AbsoluteUri);
        Debug.Log(uri.AbsolutePath);


        UnityWebRequest request = UnityWebRequest.Get(uri.AbsoluteUri);

        yield return request.SendWebRequest();

        if (request.isDone && !request.isNetworkError)
        {
            //请求得到的文本信息
            Debug.Log(request.downloadHandler.text);

            //请求得到的字节数组
            string data = Encoding.UTF8.GetString(request.downloadHandler.data);
            Debug.Log("字节数组解析后：" + data);

            //响应码：
            Debug.Log(request.responseCode);

        }
    }

    IEnumerator SendFile()
    {
        string path = "https://www.baidu.com/";
        Uri uri = new Uri(path);

        Debug.Log(uri.AbsoluteUri);
        Debug.Log(uri.AbsolutePath);

        //直接发送字符串数据给服务器
        //UnityWebRequest request = UnityWebRequest.Post(uri.AbsoluteUri, "写入的数据？？？");

        //创建表单数据
        WWWForm form = new WWWForm();
        form.AddBinaryData("name", Encoding.UTF8.GetBytes("方野"));
        form.AddBinaryData("sex", Encoding.UTF8.GetBytes("男"));
        form.AddBinaryData("Age", Encoding.UTF8.GetBytes("29"));
        //创建请求
        UnityWebRequest request = UnityWebRequest.Post(uri.AbsoluteUri, form);

        //设置Header
        request.SetRequestHeader("Content-Type", "application/json");

        //发送请求
        yield return request.SendWebRequest();


        if (request.isDone && !request.isNetworkError)
        {
            Debug.Log("响应码：" + request.responseCode);
        }
    }


    IEnumerator GetHeaders()
    {
        string path = "https://www.baidu.com/";
        Uri uri = new Uri(path);
        UnityWebRequest request = UnityWebRequest.Head(uri);
        //发送请求
        yield return request.SendWebRequest();
        //得到目标的头
        var dic = request.GetResponseHeaders();
        //打印
        foreach (var item in dic)
        {
            Debug.Log(item.Key + "----" + item.Value);
        }

    }

    //请求图片
    IEnumerator RequestTexture()
    {
        //var url = "https://www.baidu.com/img/bd_logo1.png";

        string url = "https://www.baidu.com/img/flexible/logo/pc/result.png";

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        Debug.Log("状态码:" + request.responseCode);
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            //获取图片
            Texture2D tex = DownloadHandlerTexture.GetContent(request);
            //保存
            string path = Path.Combine(Application.streamingAssetsPath, "BaiduLogo1.png");
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Byte[] data = tex.EncodeToPNG();
                fs.Write(data, 0, data.Length);
                Debug.Log("写入完成~！");
            }
        }
    }


    //请求音频
    IEnumerator RequestMedia()
    {
        var url = "https://www.?????.com/music.ogg";
        var www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.OGGVORBIS);
        yield return www.SendWebRequest();
        Debug.Log("status code:" + www.responseCode);
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            var audio = DownloadHandlerAudioClip.GetContent(www);
        }
    }

    //请求AB包
    IEnumerator InstantiateObject(string assetBundleName)
    {
        string uri = "file:///" + Application.dataPath + "/AssetBundles/" + assetBundleName;
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);
        yield return request.SendWebRequest();
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        GameObject cube = bundle.LoadAsset<GameObject>("Cube");
        GameObject sprite = bundle.LoadAsset<GameObject>("Sprite");
        Instantiate(cube);
        Instantiate(sprite);
    }




}
