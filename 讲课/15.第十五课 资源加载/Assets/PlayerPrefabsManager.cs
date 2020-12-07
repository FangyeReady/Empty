using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PlayerPrefabsManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.SetFloat("HP", 100);
            PlayerPrefs.SetInt("Age", 29);
            PlayerPrefs.SetString("Name", "FY");
        }



        if (Input.GetKeyDown(KeyCode.W))
        {
            float hp = PlayerPrefs.GetFloat("HP", 0);

            int age = PlayerPrefs.GetInt("Age", 0);

            string name = PlayerPrefs.GetString("Name", "???");


            string format = string.Format("Name:{0}, Age:{1}, HP:{2}", name, age, hp);


            Debug.Log(format);

        }




    }
}
