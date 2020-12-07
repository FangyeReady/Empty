using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Base : MonoBehaviour
{
    public Image Hpimage;
    public float Enemy_Base_Healthy;
    public float Enemyy_Base_Maxhealthy;
    Player_Money playermoney;
    // Start is called before the first frame update
    void Start()
    {
        Enemy_Base_Healthy = 10f;
        Enemyy_Base_Maxhealthy=10f;
        playermoney = GameObject.FindGameObjectWithTag("MoneyData").GetComponent<Player_Money>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy_Base_Healthy <= 0)
        {
            Destroy(this.gameObject);
            playermoney.PlayerMoney += 150f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player_Bullet")
        {
            Enemy_Base_Healthy--;
            Hpimage.fillAmount = Enemy_Base_Healthy / Enemyy_Base_Maxhealthy;
            Destroy(other.gameObject);

        }
    }


}
