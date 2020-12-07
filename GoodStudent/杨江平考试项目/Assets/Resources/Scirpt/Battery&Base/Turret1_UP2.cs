using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1_UP2 : MonoBehaviour
{
    public GameObject Turt1_up2;
    public float X = 1;
    Player_Money playermoney;
    GameObject data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("MoneyData");
        playermoney =data.GetComponent<Player_Money>();
        Turt1_up2.transform.position = transform.position;
        Turt1_up2.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (X == 1 && playermoney.PlayerMoney >= 100)
            {
                GameObject.Instantiate(Turt1_up2);
                playermoney.PlayerMoney -= 100f;
                X = 2;
                Destroy(this.gameObject);
            }

        }
        if (Input.GetMouseButton(1))
        {
            if (X == 1)
            {
                playermoney.PlayerMoney += 160f;
                Destroy(this.gameObject);
                X = 0;
            }

        }
    }
}
