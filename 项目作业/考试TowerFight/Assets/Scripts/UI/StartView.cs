using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartView : MonoBehaviour
{
    public Button startButton;
    public Text blueWin;
    public Text redWin;
    public Text pingju;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        startButton.onClick.AddListener(OnStartBtnClick);

    }

    private void OnEnable()
    {
        blueWin.text = PlayerPrefs.GetInt("bluewin", 0) + "场";
        redWin.text = PlayerPrefs.GetInt("redwin", 0) + "场";
        pingju.text = PlayerPrefs.GetInt("pingju", 0) + "场";
    }

    void OnStartBtnClick()
    {
        gameManager.StartGame();
    }
}
