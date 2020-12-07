using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBullets1 : MonoBehaviour
{
    public GameObject obj;
    GameObject data;
    Player_Money playermoney;
    /*    float time = 0.2f;
        float timeGo = 0f;*/
    // Start is called before the first frame update
    void Start()
    {
        obj = Resources.Load<GameObject>("Prefabs/Player/Player_Bullet");
        data = GameObject.FindGameObjectWithTag("MoneyData");
        playermoney = data.GetComponent<Player_Money>();
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetMouseButton(0))
        {
            timeGo += Time.deltaTime;
            if (timeGo> time)
            {
                GameObject bullet1 = GameObject.Instantiate(obj);
                bullet1.transform.parent = GameObject.Find("PlayerBullet").transform;
                GameObject GUN1 = GameObject.FindGameObjectWithTag("Gun1");
                bullet1.transform.position = GUN1.transform.position;
                bullet1.transform.rotation = GUN1.transform.rotation;
                Destroy(bullet1, 3);
                timeGo = 0f;
            }


        }*/
        if (Input.GetMouseButtonDown(2) && playermoney.PlayerMoney >= 100f)
        {
            GameObject bullet1 = GameObject.Instantiate(obj);
            bullet1.transform.parent = GameObject.Find("PlayerBullet").transform;
            GameObject GUN1 = GameObject.FindGameObjectWithTag("Gun1");
            bullet1.transform.position = GUN1.transform.position;
            bullet1.transform.rotation = GUN1.transform.rotation;
            Destroy(bullet1, 1.5f);
            playermoney.PlayerMoney -= 100f;
        }


    }
}
