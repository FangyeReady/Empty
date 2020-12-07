using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public Text time;
    public Button btn_Replay;
    public Button btn_Pause;
    public Button btn_play;


    float curTime = 180;
    float timeTotal = 0f;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        btn_Replay.onClick.AddListener(Replay);
        btn_Pause.onClick.AddListener(Pause);
        btn_play.onClick.AddListener(Play);

        btn_play.gameObject.SetActive(false);
        btn_Pause.gameObject.SetActive(true);

    }

    private void Start()
    {
        time.text = curTime.ToString();
        //InvokeRepeating("UpdateTime", 1f, 1f);
    }

    private void Update()
    {
        timeTotal += Time.deltaTime;
        if (timeTotal >= 1f)
        {
            UpdateTime();
            timeTotal = 0f;
        }
    }


    private void UpdateTime()
    {
        curTime -= 1;
        time.text = curTime.ToString();
        if (curTime <= 0f)
        {
            gameManager.GameEnd();
        }
    }


    void Replay()
    {
        gameManager.RePlayGame();
    }

    private void Pause()
    {
        gameManager.PauseGame();
        btn_play.gameObject.SetActive(true);
        btn_Pause.gameObject.SetActive(false);
    }

    private void Play()
    {
        gameManager.ContinuePlay();
        btn_play.gameObject.SetActive(false);
        btn_Pause.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        curTime = 180;
        time.text = curTime.ToString();
    }
}
