using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirth : MonoBehaviour
{
    public GameObject _Enemy;
    /*    public float timer = 5.0f;*/
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Birth());
    }

    // Update is called once per frame
    void Update()
    {

        
        /*        timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    GameObject Enemy = GameObject.Instantiate(_Enemy);
                    Enemy.transform.parent = this.transform;
                    Enemy.transform.position = transform.position;
                    Enemy.transform.rotation =  transform.rotation;
                    timer = 5.0f;

                }*/

    }
    IEnumerator Birth()
    {
        int i = 1;
        var waite= new WaitForSeconds(5f);
        while (true)
        {
            GameObject Enemy = GameObject.Instantiate(_Enemy);
            Enemy.transform.parent = this.transform;
            Enemy.transform.position = transform.position;
            Enemy.transform.rotation = transform.rotation;
            yield return waite;
            i++;
            if (i%5==0)
            {
            Enemy.GetComponent<EnemyMoves>().Speed += 0.1f*i;
            Enemy.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = Random.ColorHSV();   //和Agent脚本里面的一个意思，只是少申请了变量
            }
        }

    }
}
