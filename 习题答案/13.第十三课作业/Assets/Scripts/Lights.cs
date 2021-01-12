using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Lights : MonoBehaviour
{
    public Light[] lights;


    public void SetLightOn(int index)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = i == index;
        }
    }

}
