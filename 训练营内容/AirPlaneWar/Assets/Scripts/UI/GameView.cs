using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*九城教育*/
public class GameView : MonoBehaviour
{
    public Text scoreText;
    public Text hpText;
    public Text boomText;
    public Text superTimeText;

    public void SetScore(float score)
    {
        scoreText.text = score.ToString();
    }

    public void SetHp(float hp)
    {
        hpText.text = hp.ToString();
    }

    public void SetBoom(int boom)
    {
        boomText.text = boom.ToString();
    }

    public void SetSuperTime(float time)
    {
        superTimeText.text = string.Format("{0:F1}", time);
    }


}
