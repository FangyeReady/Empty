using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeHome : MonoBehaviour
{
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public GameObject Spider;
    public Transform enemyFather;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateSpider", 1, 5);
    }

    //在三个点位生成爆浆虫
    void CreateSpider()
    {
        GameObject go1 = Instantiate(Spider, spawnPoint1.position, spawnPoint1.rotation);
        go1.tag = "goUp1";
        go1.transform.SetParent(enemyFather);
        GameManager.instance.spiderList.Add(go1);
        GameObject go2 = Instantiate(Spider, spawnPoint2.position, spawnPoint2.rotation);
        go2.tag = "goMid1";
        go2.transform.SetParent(enemyFather);
        GameManager.instance.spiderList.Add(go2);
        GameObject go3 = Instantiate(Spider, spawnPoint3.position, spawnPoint3.rotation);
        go3.tag = "goDown1";
        go3.transform.SetParent(enemyFather);
        GameManager.instance.spiderList.Add(go3);
    }
    //基地被攻击方法
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="AttackShape2")
        {
            print("眼睛被攻击了!!!!");
            GameManager.instance.eyeHp -= JunkMan.instance.attack;
            if (GameManager.instance.eyeHp<=0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
