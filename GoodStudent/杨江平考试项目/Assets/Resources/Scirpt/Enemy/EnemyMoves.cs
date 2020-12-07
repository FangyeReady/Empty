using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoves : MonoBehaviour
{
    GameObject data;
    Player_Money playermoney;

    GameObject _Targt;
    public Rigidbody rig;
    Vector3 Distance_Vector;
    public float Enemy_Healthy = 5;
    public float Enemy_Maxhealthy = 5;
    public float Speed = 1;
    Vector3 Move_for;
    public Image Hpimage;  //血条，  Image 要用using UnityEngine.UI; 导入
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        _Targt = GameObject.FindGameObjectWithTag("Player_Base");
        Distance_Vector = _Targt.transform.position - transform.position;
        //        HPimage = Resources.Load<Image>("Img/hp");
        data = GameObject.FindGameObjectWithTag("MoneyData");
        playermoney = data.GetComponent<Player_Money>();

    }

    private void FixedUpdate()
    {

        
    }
    // Update is called once per frame
    void Update()
    {
        Move_for = Vector3.Normalize(Distance_Vector) * Time.deltaTime*2;
        transform.position = transform.position + Move_for*Speed;
        //transform.Translate(Vector3.forward*Time.deltaTime*2);
        transform.LookAt(_Targt.transform);
        if (Enemy_Healthy <= 0)
        {
            playermoney.PlayerMoney ++;
            Destroy(this.gameObject);
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {



        if (other.tag=="Finish")
             {
                Debug.Log("中弹");
                Enemy_Healthy--;
                Destroy(other.gameObject);
                Hpimage.fillAmount = Enemy_Healthy / Enemy_Maxhealthy;
                
            }
        if (other.tag == "Finish2")
            {
                Debug.Log("中导弹");
                Enemy_Healthy=Enemy_Healthy-2;
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
