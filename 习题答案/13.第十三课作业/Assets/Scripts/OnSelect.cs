using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class OnSelect : MonoBehaviour
{
    Lights lights;
    private void Awake()
    {
        lights = GameObject.FindObjectOfType<Lights>();
    }

    private void OnMouseEnter()
    {
        lights.SetLightOn(int.Parse(gameObject.name));
    }
}
