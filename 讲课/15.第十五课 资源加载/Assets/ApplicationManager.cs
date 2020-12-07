using System.Collections.Generic;
using System.IO;
using UnityEngine;
/*九城教育*/

 //使得脚本可以在编辑模式运行
//[ExecuteInEditMode]
public class ApplicationManager : MonoBehaviour
{
    private void Start()
    {
        //Debug.Log("平台:" + Application.platform);//平台
        //Debug.Log("数据目录:" + Application.dataPath);//数据目录，即当前程序的资源目录，Editor时是Assets文件夹，运行时是 _Data文件夹
        //Debug.Log("沙盒目录下的数据目录:" + Application.persistentDataPath);//沙盒目录下的数据目录，可读可写，但不可预读预写，仅能在安装程序后生成，且在程序运行时可用
        //Debug.Log("streamingAssetsPath:" + Application.streamingAssetsPath);//和Resources文件夹类似，只读，但是其中的内容均不会进行压缩，且该文件夹必须在Assets的下一级目录，有且仅有一个
        //Debug.Log("帧率:" + Application.targetFrameRate);//可用于设置目标帧率，和渲染，优化有关，暂时不管
        //Debug.Log("程序是否可以在后台运行:" + Application.runInBackground);//程序是否可以在后台运行
        //Debug.Log("当前程序的Unity版本:" + Application.unityVersion);//当前程序的Unity版本
        //Debug.Log("前程序是否在运行:" + Application.isPlaying);//当前程序是否在运行，若在运行，返回true;[ExecuteInEditMode]作用于类，且仅调用一次，或聚焦时调用一次。
        //Debug.Log("当前系统的操作语言:" + Application.systemLanguage);//当前系统的操作语言， 中国就是中文


        //if (!Application.isPlaying)
        //{
        //    Debug.Log("当前是调试模式~");
        //}

        //注册退出事件,用于在程序退出时调用
        Application.wantsToQuit += QuitEventFunc;

    }

    bool QuitEventFunc()
    {
        Debug.Log("程序退出事件!");
        return true;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Application.OpenURL("https://fanyi.baidu.com/");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            //Application.CaptureScreenshot(Application.dataPath + "text.png");

            //ScreenCapture.CaptureScreenshot(Path.Combine(Application.dataPath, "截图01.png"));


            ScreenCapture.CaptureScreenshot(Path.Combine(Application.dataPath, "截图02.png"), ScreenCapture.StereoScreenCaptureMode.RightEye);
        }

    }
}
