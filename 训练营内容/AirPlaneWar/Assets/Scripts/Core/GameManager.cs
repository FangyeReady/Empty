using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*九城教育*/
public class GameManager : MonoBehaviour
{
    //设置单例模式
    private static GameManager _instance;
    public static GameManager Instance{
        get {
            return _instance; 
        }
    }

    //最大血量
    private float maxHP = 100f;
    public float MaxHP {
        get {
            return maxHP;
        }
    }

    //最大炸弹数量
    private int maxBoomCount = 5;
    public int MaxBoomCount
    {
        get
        {
            return maxBoomCount;
        }
    }

    //用于控制游戏开始
    private bool startGame = false;
    public bool StartGame
    {
        get
        {
            return startGame;
        }
    }


    GameObject bossPrefab;


    private void Awake()
    {
        //初始化
        _instance = this;
    }


    private void Start()
    {
        bossPrefab = Resources.Load<GameObject>("Boss");
    }

    public void CreateBoss()
    {
        Instantiate(bossPrefab, new Vector3(0, 0, 120), Quaternion.Euler(0, 180, 0));
    }

    //响应开始按钮点击
    public void OnGameStart()
    {
        startGame = true;

        UIManager.Instance.OnGameStart();
    }

    public void OnGameEnd()
    {
        //触发游戏结束的逻辑
        StartCoroutine(End());
    }

    /// <summary>
    /// 游戏结束
    /// </summary>
    /// <returns></returns>
    IEnumerator End()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }


   

}
