using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class PlayerMoveController : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        //如果未开始游戏,就无法移动
        if (GameManager.Instance.IsStartGame() == false)
        {
            return;
        }


        float hOffset = Input.GetAxis("Horizontal");//获取水平方向的移动增量
        float vOffset = Input.GetAxis("Vertical");//获取竖直方向的移动增量

        //如果达到左边边界, 仍想往左边移动的, 则移动增量设置为0
        if (transform.position.x <= -15 && hOffset < 0f)
        {
            hOffset = 0f;
        }

        //如果达到右边边界, 仍想往右边移动的, 则移动增量设置为0
        if (transform.position.x >= 15 && hOffset > 0f)
        {
            hOffset = 0f;
        }

        //如果达到下边边界, 仍想往下边移动的, 则移动增量设置为0
        if (transform.position.z <= -36 && vOffset < 0f)
        {
            vOffset = 0f;
        }

        //如果达到上边边界, 仍想往上边移动的, 则移动增量设置为0
        if (transform.position.z >= 36 && vOffset > 0f)
        {
            vOffset = 0f;
        }

        //移动
        transform.Translate(new Vector3( hOffset * Time.deltaTime * speed,  0f,  vOffset * Time.deltaTime  * speed) );
    }
}
