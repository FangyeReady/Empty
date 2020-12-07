using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Money : MonoBehaviour
{
    public float PlayerMoney;
    public Text MoneyText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMoney = 300;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = "¥" + PlayerMoney;
    }
}
