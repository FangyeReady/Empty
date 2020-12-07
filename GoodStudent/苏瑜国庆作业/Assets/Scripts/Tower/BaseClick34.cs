using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClick34 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color color;

    public GameObject EyeTower;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.material.color;
    }

    private void OnMouseEnter()
    {
        spriteRenderer.material.color = Color.red;
    }
    private void OnMouseExit()
    {
        spriteRenderer.material.color = color;
    }
    private void OnMouseDown()//鼠标点击建造
    {
        if (GameManager.instance.UseEyeCoin(20))//建造花费20眼睛币
        {
            Destroy(this.gameObject);
            Instantiate(EyeTower, transform.position, Quaternion.identity);
        }
    }

}
