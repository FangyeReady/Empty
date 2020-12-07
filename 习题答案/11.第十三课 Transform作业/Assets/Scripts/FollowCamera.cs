using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class FollowCamera : MonoBehaviour
{
    public float followSpeed = 10f;
    GameObject player;
    Vector3 offset = Vector3.zero;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            offset = transform.position - player.transform.position;//得到Player到摄像机的向量



            Debug.Log(offset);
        }
    }

    private void Update()
    {
       // transform.position = player.transform.position + offset; //Player的位置加上其相对于摄像机的偏移量，则为摄像机此时的位置

        Vector3 targetPos = new Vector3(player.transform.position.x,  0, player.transform.position.z);
        transform.position = targetPos + Vector3.up * 30;
        transform.LookAt(player.transform);
    }
}
