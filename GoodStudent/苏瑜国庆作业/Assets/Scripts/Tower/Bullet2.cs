﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<JunkMan>() != null)
        {
            //collision.GetComponent<JunkMan>().hp -= 5;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(gameObject, 5);
        }
    }

}
