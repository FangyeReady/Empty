using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Boss : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform midPoint;
    public Transform player;

    public GameObject bullet;

    float timer = 0f;
    float fireInterval = 0.5f;
    float percent = 0f;


    bool isFireSkill = false;
    

    private void Start()
    {
        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireInterval && !isFireSkill)
        {
            timer = 0f;

            Fire();
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            FireSkill();
        }

        //开启技能1时调用
        if (isFireSkill)
        {
            float y = Mathf.PingPong(percent, 240);
            //midPoint.localRotation = Quaternion.Euler(0, -120 + y, 0);
            percent += 3f;
        }
        else
        {
            percent = 0f;
            midPoint.rotation = Quaternion.identity;
        }

    }



    void Fire()
    {
        if (player == null)
        {
            return;
        }

        Vector3 dir1 = player.position - point1.position;
        Vector3 dir2 = player.position - point2.position;

        Quaternion targetRotation1 = Quaternion.LookRotation(dir1);
        Quaternion targetRotation2 = Quaternion.LookRotation(dir2);



        Instantiate(bullet, point1.position, targetRotation1);
        Instantiate(bullet, point2.position, targetRotation2);
    }


    void FireSkill()
    {
        isFireSkill = true;

        //StartCoroutine(Skill1());

        StartCoroutine(Skill2());
    }


    IEnumerator Skill1()
    {
        while (true)
        {
            Instantiate(bullet, midPoint.position, midPoint.rotation);
            yield return new WaitForSeconds(0.05f);

            if (!isFireSkill)
            {
                break;
            }
        }
    }

    IEnumerator Skill2()
    {
        while (true)
        {
            for (int i = -10; i <= 10; i++)
            {    
                Instantiate(bullet, midPoint.position, Quaternion.Euler(0, 180 - i * 12, 0));
            }
   
            yield return new WaitForSeconds(1f);

            if (!isFireSkill)
            {
                break;
            }
        }
    }
}
