using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birth_Turret : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public Renderer m;
    GameObject data;
    Player_Money playermoney;
    public Color c;
    public Color e;
    public float X = 0;
    Vector3 fort = new Vector3(0, 0.35f, 0);
    // Start is called before the first frame update
    void Start()
    {
        m = GetComponent<MeshRenderer>();
        c=m.material.color;
        data = GameObject.FindGameObjectWithTag("MoneyData");
        playermoney = data.GetComponent<Player_Money>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseEnter()
    {
        if ((X == 1))
        {
            m.material.color = c;
        }
        else
        {
            m.material.color = e;
        }
        
    }
    private void OnMouseExit()
    {
        m.material.color = c;
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (X==0 && playermoney.PlayerMoney>=50)
            {
                GameObject A = GameObject.Instantiate(a);
                A.transform.position = transform.position + fort;
                A.transform.parent = transform;
                playermoney.PlayerMoney -= 50f;
                X = 1;
            }

        }
        if (Input.GetMouseButton(1) && playermoney.PlayerMoney >= 100)
        {
            if (X==0)
            {
                GameObject B = GameObject.Instantiate(b);
                B.transform.position = transform.position + fort;
                B.transform.parent = transform;
                playermoney.PlayerMoney -= 100f;
                X = 1;
            }

        }
    }
    
}
