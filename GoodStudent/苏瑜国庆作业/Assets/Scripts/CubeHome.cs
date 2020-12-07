using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHome : MonoBehaviour
{
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public GameObject junkMan;
    public Transform enemyFather;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateJunkMan", 1, 5);
    }

    //在三个点位生成拾荒者
    void CreateJunkMan() {
      GameObject go1 = Instantiate(junkMan, spawnPoint1.position, Quaternion.identity);
        go1.tag = "goUp";
        go1.transform.SetParent(enemyFather);
        GameManager.instance.junkManList.Add(go1);
      GameObject go2 = Instantiate(junkMan, spawnPoint2.position, Quaternion.identity);
        go2.tag = "goMid";
        go2.transform.SetParent(enemyFather);
        GameManager.instance.junkManList.Add(go2);
        GameObject go3 = Instantiate(junkMan, spawnPoint3.position, Quaternion.identity);
        go3.tag = "goDown";
        go3.transform.SetParent(enemyFather);
        GameManager.instance.junkManList.Add(go3);
    }
    //基地被攻击方法
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AttackShape1")
        {
            print("方块被攻击了!!!!");
            GameManager.instance.cubeHp -= Spider.instance.attack;
            if (GameManager.instance.cubeHp<=0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
