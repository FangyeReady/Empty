using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAgent_HP : MonoBehaviour
{
    public Image Hpimage;
    public float Enemy_Healthy ;
    public float Enemy_Maxhealthy ;
    public float Speed ; 
    GameObject data;
    Player_Money playermoney;
    public float Enemy_deth_money=2;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("MoneyData");
        playermoney = data.GetComponent<Player_Money>();
 //       HPimage = Resources.Load<Image>("Img/hp.png");
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy_Healthy <= 0)
        {
            playermoney.PlayerMoney += 2;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Finish")
        {
            Debug.Log("中弹");
            Enemy_Healthy--;
            Destroy(other.gameObject);
            Hpimage.fillAmount = Enemy_Healthy / Enemy_Maxhealthy;

        }
        if (other.tag == "Finish2")
        {
            Debug.Log("中导弹");
            Enemy_Healthy = Enemy_Healthy - 2;
            Destroy(other.gameObject);
            Hpimage.fillAmount = Enemy_Healthy / Enemy_Maxhealthy;

        }

        if (other.tag == "Player_Base")
        {

            Destroy(this.gameObject);

        }
        if (other.tag == "Player")
        {
            Debug.Log("基地受到伤害");
            Destroy(this.gameObject);
        }
        if (other.tag == "Player_Bullet")
        {

            Destroy(this.gameObject);

        }
    }


}
