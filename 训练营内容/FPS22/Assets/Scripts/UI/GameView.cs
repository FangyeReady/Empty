using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*九城教育*/
public class GameView : MonoBehaviour
{
    //血量的图片
    public Image bloodImage;

    /// <summary>
    /// 更新血量UI
    /// </summary>
    /// <param name="hp"></param>
    public void UpdateBloodUI(float hp)
    {
        //修改血量图片的填充度
        bloodImage.fillAmount = hp / 100f;
    }
}
