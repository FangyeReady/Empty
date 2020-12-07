using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] GameView gameView;
    [SerializeField] StartView startView;

    private void Awake()
    {
        Instance = this;
    }


    public void UpdateHealth(int health)
    {
        gameView.UpdateHealth(health);
    }

    public void UpdateBoomNum(int boomNum)
    {
        gameView.UpdateBoomNum(boomNum);
    }

    public void UpdateSuperTime(float superTime)
    {
        gameView.UpdateSuperTime(superTime);
    }

    public void UpdateScore(int scoreVal)
    {
        gameView.UpdateScore(scoreVal);
    }


    public void GameEndEvent()
    {
        gameView.ResetUI();
        gameView.gameObject.SetActive(false);
        startView.gameObject.SetActive(true);
    }

    public void GameStartEvent()
    {
        gameView.ResetUI();
        gameView.gameObject.SetActive(true);
        startView.gameObject.SetActive(false);
    }

}
