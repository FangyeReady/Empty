using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClick12 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color color;

    public GameObject cubeTower;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.material.color;
    }

    private void OnMouseEnter()
    {
        spriteRenderer.material.color = Color.green;
    }
    private void OnMouseExit()
    {
        spriteRenderer.material.color = color;
    }
    private void OnMouseDown()//鼠标点击建造
    {
        if (GameManager.instance.UseCubeCoin(20))//建造花费20方块币
        {
            Destroy(this.gameObject);
            Instantiate(cubeTower, transform.position, Quaternion.identity);
        }
    }

}
