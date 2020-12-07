using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int cubeCoin = 0;//方块币
    public int eyeCoin = 0;//眼睛币
    public int cubeHp = 100;//方块基地血量
    public int eyeHp = 100;//眼睛基地血量

    public List<GameObject> junkManList = new List<GameObject>();
    public List<GameObject> spiderList = new List<GameObject>();

    public Text cubeCoinText;
    public Text eyeCoinText;
    public Text cubeHpText;
    public Text EyeHpText;
    public Text GameOverText;
    public Text GameScoreText;
    private int eyeScore = 0;
    private int cubeScore = 0;

    private bool switch1 =true;
    private void Awake()
    {
        Time.timeScale = 0;//暂停游戏
        instance = this;
    }
    private void Update()
    {
        cubeCoinText.text = "CubeCoin:" + cubeCoin;
        eyeCoinText.text = "EyeCoin:" + eyeCoin;
        cubeHpText.text = "CubeHP:" + cubeHp;
        EyeHpText.text = "EyeHp:" + eyeHp;
        GameOver();
    }
    //使用方块币的方法
    public bool UseCubeCoin(int coinNum) {
        if (cubeCoin>=coinNum)
        {
            cubeCoin -= coinNum;
            print("花费方块币成功~");
            return true;
        }
        else
        {
            print("方块币不足~");
            return false;
        }
    }

    //使用眼睛币的方法
    public bool UseEyeCoin(int coinNum)
    {
        if (eyeCoin >= coinNum)
        {
            eyeCoin -= coinNum;
            print("花费眼睛币成功~");
            return true;
        }
        else
        {
            print("眼睛币不足~");
            return false;
        }
    }

    //显示游戏结果的关卡
    public void GameOver() {
        if (cubeHp <= 0)
        {
            if (switch1)
            {
                GameOverText.enabled = true;
                GameScoreText.enabled = true;
                GameOverText.text = "GameOver:爆浆虫胜利!";
                if (PlayerPrefs.GetInt("eye", 0) == 0 && PlayerPrefs.GetInt("cube") == 0)
                {
                    GameScoreText.text = "比分结果:" + 0 + ":" + 1;
                    eyeScore = PlayerPrefs.GetInt("eye", 0);
                    eyeScore++;
                    PlayerPrefs.SetInt("eye", eyeScore);
                }
                else
                {
                    eyeScore = PlayerPrefs.GetInt("eye", 0);
                    eyeScore++;
                    PlayerPrefs.SetInt("eye", eyeScore);
                    GameScoreText.text = "比分结果:" + PlayerPrefs.GetInt("cube", 0) + ":" + PlayerPrefs.GetInt("eye");
                }
                switch1 = false;
            }
        }
        if (eyeHp<=0)
        {
            if (switch1)
            {
                GameOverText.enabled = true;
                GameScoreText.enabled = true;
                GameOverText.text = "GameOver:拾荒者胜利!";
                if (PlayerPrefs.GetInt("cube", 0) == 0&&PlayerPrefs.GetInt("eye")==0)
                {
                    GameScoreText.text = "比分结果:" + 1 + ":" + 0;
                    cubeScore = PlayerPrefs.GetInt("cube", 0);
                    cubeScore++;
                    PlayerPrefs.SetInt("cube", cubeScore);
                }
                else
                {
                    cubeScore = PlayerPrefs.GetInt("cube", 0);
                    cubeScore++;
                    PlayerPrefs.SetInt("cube", cubeScore);
                    GameScoreText.text = "比分结果:" + PlayerPrefs.GetInt("cube") + ":" + PlayerPrefs.GetInt("eye", 0);
                }
                switch1 = false;
            }
        }
    }
   
}
