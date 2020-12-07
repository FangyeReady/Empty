using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*九城教育*/
public class GameView : MonoBehaviour
{
    //血量的图片
    public Image bloodImage;
    //分数的UI
    public Text scoreText;
    //分数
    int score = 0;


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

}
