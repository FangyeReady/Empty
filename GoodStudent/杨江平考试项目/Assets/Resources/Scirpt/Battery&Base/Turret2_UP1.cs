using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2_UP1 : MonoBehaviour
{
    public GameObject Turt2_up1;
    public float X = 0;
    Player_Money playermoney;
    GameObject data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("MoneyData");
        playermoney =data.GetComponent<Player_Money>();
        Turt2_up1.transform.position = transform.position;
        Turt2_up1.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (X == 0 && playermoney.PlayerMoney >= 150)
            {
                GameObject.Instantiate(Turt2_up1);
                playermoney.PlayerMoney -= 150f;
                X = 1;
                Destroy(this.gameObject);
            }

        }
        if (Input.GetMouseButton(1))
        {
            if (X == 1)
            {
                playermoney.PlayerMoney += 80f;
                Destroy(this.gameObject);
                X = 0;
            }

        }
    }
}
