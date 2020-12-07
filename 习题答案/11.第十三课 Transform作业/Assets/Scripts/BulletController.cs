using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*九城教育*/
public class BulletController : MonoBehaviour
{
    [Range(10, 50)]
    float speed = 10f;

    private void Awake()
    {
        GameObject.Destroy(this.gameObject, 10f);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
    }

    private void OnDestroy()
    {
        Debug.Log("子弹被销毁~~~");
    }
}
