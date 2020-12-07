using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpwanSoliders blue;
    public SpwanSoliders red;

    public GameObject startView;
    public GameObject gameView;

    public Health blueHealth;
    public Health redHealth;

    public void StartGame()
    {
        blue.SetGameStart();
        red.SetGameStart();
        Time.timeScale = 1f;

        startView.SetActive(false);
        gameView.SetActive(true);

        blueHealth.SetHealth(10);
        redHealth.SetHealth(10);
    }

    public void PauseGame()
    {
        blue.SetGamePause();
        red.SetGamePause();
        Time.timeScale = 0f;
    }

    public void ContinuePlay()
    {
        Time.timeScale = 1f;
        blue.ContinuePlay();
        red.ContinuePlay();
    }

    public void RePlayGame()
    {


        SoliderController[] soliders = FindObjectsOfType<SoliderController>();
        for (int i = 0; i < soliders.Length; i++)
        {
            Destroy(soliders[i].gameObject);
        }



        blueHealth.SetHealth(10);
        blueHealth.gameObject.SetActive(true);

       
        redHealth.SetHealth(10);
        redHealth.gameObject.SetActive(true);



        startView.SetActive(true);
        gameView.SetActive(false);
    }

    public void GameEnd()
    {
        Debug.LogWarning("游戏结束~~~");
        int bluewin = PlayerPrefs.GetInt("bluewin", 0);
        int redwin = PlayerPrefs.GetInt("redwin", 0);
        int pingju = PlayerPrefs.GetInt("pingju", 0);


        int redHealthVal = redHealth.GetHealth();
        int blueHealVal = blueHealth.GetHealth();

        if (redHealthVal > blueHealVal)
        {
            redwin += 1;
        }
        else if(redHealthVal < blueHealVal)
        {
            bluewin += 1;
        }
        else
        {
            pingju += 1;
        }


        PlayerPrefs.SetInt("bluewin",bluewin);
        PlayerPrefs.SetInt("redwin", redwin);
        PlayerPrefs.SetInt("pingju", pingju);

        RePlayGame();
        blue.SetGamePause();
        red.SetGamePause();
    }

}
