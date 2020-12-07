using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class SpwanCube : MonoBehaviour
{
    public GameObject cube;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = -5; j < 5; j++)
            {
                Transform item = Instantiate(cube, transform).transform;
                item.localPosition = new Vector3(j , i + 0.5f, 0f);
                item.localRotation = Quaternion.identity;
            }
        }
    }




}
