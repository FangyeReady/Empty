using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBullets2 : MonoBehaviour
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
            if (timeGo > time)
            {
                GameObject bullet2 = GameObject.Instantiate(obj);
                bullet2.transform.parent = GameObject.Find("PlayerBullet").transform;

                GameObject GUN2 = GameObject.FindGameObjectWithTag("Gun2");
                bullet2.transform.position = GUN2.transform.position;
                bullet2.transform.rotation = GUN2.transform.rotation;
                Destroy(bullet2, 3);
                timeGo = 0f;
            }
        }*/
        if (Input.GetMouseButtonDown(2)&& playermoney.PlayerMoney>=100f)
        {
            GameObject bullet2 = GameObject.Instantiate(obj);
            bullet2.transform.parent = GameObject.Find("PlayerBullet").transform;
            GameObject GUN2 = GameObject.FindGameObjectWithTag("Gun2");
            bullet2.transform.position = GUN2.transform.position;
            bullet2.transform.rotation = GUN2.transform.rotation;
            Destroy(bullet2, 1.5f);
            // bullet2.transform.Translate(Vector3.forward* speed);
        }
    }
}
