using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class UIManager : MonoBehaviour
{
    //设置单例模式
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }

    //游戏界面
    public GameView gameView;
    //开始界面
    public StartView startView;

    //分数
    float scoreCount = 0f;

    bool hasBoss = false;

    private void Awake()
    {
        _instance = this;
    }




    /// <summary>
    /// 更新分数
    /// </summary>
    /// <param name="score"></param>
    public void UpdateScore(float score)
    {
        scoreCount = scoreCount + score;
        gameView.SetScore(scoreCount);


        if (scoreCount >= 100 && !hasBoss)
        {
            hasBoss = true;
            GameManager.Instance.CreateBoss();
        }
    }

    /// <summary>
    /// 设置血量
    /// </summary>
    /// <param name="hp"></param>
    public void UpdateHp(float hp)
    {
        gameView.SetHp(hp);
    }


    public void UpdateBoom(int boomNum)
    {
        gameView.SetBoom(boomNum);
    }


    public void UpdateSuperTime(float supertime)
    {
        gameView.SetSuperTime(supertime);
    }


    public void OnGameStart()
    {
        gameView.gameObject.SetActive(true);
        startView.gameObject.SetActive(false);
    }

}
