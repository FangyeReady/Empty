using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2_SELLUP2 : MonoBehaviour
{
    public float X = 2;
    Player_Money playermoney;
    GameObject data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("MoneyData");
        playermoney =data.GetComponent<Player_Money>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(1))
        {
            if (X == 2)
            {
                playermoney.PlayerMoney += 320f;
                Destroy(this.gameObject);
                X = 0;
            }

        }
    }
}
