using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*九城教育*/
public class HurtEffect : MonoBehaviour
{
    //闪烁的速度
    public float speed = 2;
    //闪烁的图片
    Image img;

    //闪烁状态
    bool showEffect = false;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        if (showEffect)
        {
            img.color = new Color(1, 0, 0, 0.5f);
        }
        else
        {
            img.color = Color.Lerp(img.color, Color.clear, Time.deltaTime * speed);
        }

        showEffect = false;

    }

    /// <summary>
    /// 播放闪烁效果
    /// </summary>
    public void PlayEffect()
    {
        showEffect = true;
    }
}
