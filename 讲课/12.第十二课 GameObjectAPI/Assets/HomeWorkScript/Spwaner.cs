using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Spwaner : MonoBehaviour
{
    public int Count;

    public GameObject itemPrefab;

    List<GameObject> objectsList = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < Count; i++)
            {
                // GameObject.Instantiate(itemPrefab, new Vector3(i, 0, 0), Quaternion.identity);
               GameObject obj = GameObject.Instantiate(itemPrefab);
                int x = i * 2;
               obj.transform.position = new Vector3(x, 0, 0);

               objectsList.Add(obj);
            }
        }

        //重新显示
        if (Input.GetKeyDown(KeyCode.B))
        {
            for (int i = 0; i < objectsList.Count; i++)
            {
                GameObject obj = objectsList[i];

                if (!obj.activeSelf)
                {
                    obj.SetActive(true);
                }
            }
        }

        
    }
}
