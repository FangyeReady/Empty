using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public Target target;
    public Transform paoTai;
    public Transform bulletPos;
    public float rotateSpeed = 10;
    public int attack = 1;

    List<GameObject> enemies = new List<GameObject>();
    GameObject curTarget = null;
    GameObject bullet;
    bool canFire = false;
    string targetTag;

    float fireInterval = 0.5f;
    float timeAdd = 0f;

    private void Awake()
    {
        switch (target)
        {
            case Target.RedSolider:
                targetTag = "RedSolider";
                break;
            case Target.BlueSolider:
                targetTag = "BlueSolider";
                break;
            default:
                targetTag = "";
                break;
        }
    }

    private void Start()
    {
        bullet = Resources.Load<GameObject>("Bullet");
    }


    private void Update()
    {
        if (!canFire)
        {
            paoTai.localRotation = Quaternion.identity;
            return;
        }

        if (curTarget != null )
        {
            Quaternion targetRotation = Quaternion.LookRotation(curTarget.transform.position - paoTai.position);
            paoTai.rotation = Quaternion.Lerp(paoTai.rotation, targetRotation, Time.deltaTime * rotateSpeed);
            float angle = Quaternion.Angle(paoTai.rotation, targetRotation);

            if (angle < 30f && timeAdd >= fireInterval)
            {
                //发射子弹
                Fire();
                timeAdd = 0f;
            }
            else
            {
                timeAdd += Time.deltaTime;
            }
        }

    }


    void Fire()
    {
        GameObject obj = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        obj.gameObject.GetComponent<BulletController>().Attack = attack;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            if (!enemies.Contains(other.gameObject))
            {
                enemies.Add(other.gameObject);
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        float maxDistance = 0f;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                float distance = Vector3.Distance(this.transform.position, enemies[i].transform.position);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    curTarget = enemies[i];
                }
            }
          
        }

        //开火
        canFire = curTarget != null;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            if (enemies.Contains(other.gameObject))
            {
                enemies.Remove(other.gameObject);
            }
        }
    }
}
