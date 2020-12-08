using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*九城教育*/
public class GameView : MonoBehaviour
{
    //开始按钮
    public Button startBtn;
    //end图片
    public Image endImage;
    //血量的图片
    public Image bloodImage;
    //分数的UI
    public Text scoreText;
    //战斗界面的UI收纳
    public GameObject gameContainer;
    //游戏名称
    public GameObject gameName;

    //表示游戏是否开始
    private bool isStartingGame = false;
    public bool IsStartingGame
    {
        get { return isStartingGame; }
    }

    //分数
    int score = 0;
    //图片颜色
    Color targetColor;

    private void Start()
    {
        targetColor = new Color(  endImage.color.r, endImage.color.g, endImage.color.b, 1f );

        //注册按钮点击事件
        startBtn.onClick.AddListener( OnStartButtonClick );

    }


    private void Update()
    {
        //用于控制退出
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// 更新血量UI
    /// </summary>
    /// <param name="hp"></param>
    public void UpdateBloodUI(float hp)
    {
        //修改血量图片的填充度
        bloodImage.fillAmount = hp / 100f;
    }

    /// <summary>
    /// 更新分数
    /// </summary>
    /// <param name="val"></param>
    public void UpdateScoreUI(int val)
    {
        //更新分数
        score = score + val;
        //更新文本
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// 获取分数
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return score;
    }

    /// <summary>
    /// 游戏结束时调用
    /// </summary>
    public void OnGameEnd()
    {
        StartCoroutine(ShowEndEff());
    }

    /// <summary>
    /// 展示游戏结束时的效果
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowEndEff()
    {
        endImage.transform.GetComponentInChildren<Text>().enabled = true;

        while (true)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            endImage.color = Color.Lerp(endImage.color, targetColor, Time.deltaTime * 2);
        }
    }


    /// <summary>
    /// 开始游戏
    /// </summary>
    public void OnStartButtonClick()
    {
        //Debug.Log("点击了OnStartButtonClick");
        //点击按钮后, 展示战斗界面,隐藏开始界面
        gameContainer.SetActive(true);
        startBtn.gameObject.SetActive(false);
        gameName.SetActive(false);

        //设置游戏状态为true
        isStartingGame = true;

        //开始生产敌人
        GameObject.FindObjectOfType<EnemyManager>().CreateEnemies();
    }

}
