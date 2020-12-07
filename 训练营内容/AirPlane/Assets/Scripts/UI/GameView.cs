using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GameView : MonoBehaviour
{
    [SerializeField] Text healthText;
    [SerializeField] Text boomNumText;
    [SerializeField] Text superTimeText;

    [SerializeField] Text curScore;
    int score;

    private void Awake()
    {
        ResetUI();
    }

    public void UpdateHealth(int health)
    {
        healthText.text = health.ToString();
    }

    public void UpdateBoomNum(int boomNum)
    {
        boomNumText.text = boomNum.ToString();
    }

    public void UpdateSuperTime(float superTime)
    {
        superTimeText.text = string.Format("{0:F1}", superTime);
    }

    public void UpdateScore(int scoreVal)
    {
        score += scoreVal;
        curScore.text = score.ToString();
    }

    public void ResetUI()
    {
        healthText.text = GameManager.Instance.GetMaxHealth().ToString();
        boomNumText.text = GameManager.Instance.GetMaxBoomCount().ToString();
        superTimeText.text = "0.0";

        curScore.text = "0";
        score = 0;
    }
}
