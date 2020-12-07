using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    int val = 10;

    public Text textHP;
    public bool isSolider = false;


    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        if (textHP)
        {
            textHP.text = val.ToString();
        }
    }

    public void OnAttack(int attack)
    {
        val -= attack;
        if (val <= 1)
        {
            val = 0;
            Die();
            
        }
        if (textHP)
        {
            textHP.text = val.ToString();

            if (IsDie())
            {
                gameManager.GameEnd();
            }
        }
    }

    private void Die()
    {
        if (isSolider)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

    public void SetHealth(int hp)
    {
        val = hp;
        if (textHP)
        {
            textHP.text = val.ToString();
        }
    }

    public int GetHealth()
    {
        return val;
    }

    public bool IsDie()
    {
        return val == 0f;
    }

    private void OnDisable()
    {
        if (textHP)
        {
            textHP.text = 10 + "";
        }
    }
}
