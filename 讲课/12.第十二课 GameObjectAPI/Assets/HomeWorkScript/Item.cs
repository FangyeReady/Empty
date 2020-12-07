using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Item : MonoBehaviour
{
    private void OnMouseDown()
    {
         this.gameObject.SetActive(false);

        //Destroy(this.gameObject);
    }
}
