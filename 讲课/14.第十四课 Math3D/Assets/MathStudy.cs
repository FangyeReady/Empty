using System;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class MathStudy : MonoBehaviour
{


    public float curValue = 0f;
    float targetValue = 10f;

    private void Awake()
    {
       Debug.Log("绝对值: " +  Mathf.Abs( -99 ));//绝对值 
       Debug.Log("最大值:" + Mathf.Max(99, 100));//最大值 ,min
       Debug.Log("限制在0-100:"  + Mathf.Clamp(-99, 0, 100));//value会被限制在min至max之间
       Debug.Log("限制在0-1:" +  Mathf.Clamp01(99));//val限制在0和1之间 
       Debug.Log("四舍五入:" +  Mathf.Round(1.3f) + "  " + Mathf.Round(1.6f));//四舍五入 
       Debug.Log("向上取整:" +  Mathf.Ceil(1.1f));//向上取整
       Debug.Log("向下取整:" +  Mathf.Floor(1.9f));//向下取整
       Debug.Log("N次方:" +  Mathf.Pow(2, 3));//求f的p次方

    }


    private void Update()
    {
       

    }


}
