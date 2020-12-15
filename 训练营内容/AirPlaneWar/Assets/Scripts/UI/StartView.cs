using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*九城教育*/
public class StartView : MonoBehaviour
{
    //开始按钮
    public Button startButton;


    private void Awake()
    {
        //开始按钮注册事件
        startButton.onClick.AddListener(OnStartButtonClick);
    }

    //点击开始按钮后调用
    private void OnStartButtonClick()
    {
        //调用游戏开始逻辑
        GameManager.Instance.OnGameStart();
    }
}
