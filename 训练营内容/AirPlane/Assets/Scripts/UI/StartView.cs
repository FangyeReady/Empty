using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*九城教育*/
[Serializable]
public class StartView : MonoBehaviour
{
    //开始按钮
    public Button startButton;

    public AudioSource audio;

    private AudioClip StartButtonClickVoice;

    private void Awake()
    {
        //绑定开始按钮的方法
        startButton.onClick.AddListener(  OnStartButtonClick  );
    }

    private void Start()
    {
        StartButtonClickVoice = Resources.Load<AudioClip>("VoiceStartButtonClick");
    }

    //点击开始按钮后,触发的方法
    void OnStartButtonClick()
    {
        //调用游戏管理器中的开始游戏方法
        GameManager.Instance.StartGame();

        audio.clip = StartButtonClickVoice;
        audio.Play();
        //隐藏自身UI
        this.gameObject.SetActive(false);
    }
}
