using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoliderController : MonoBehaviour
{
    public Health hp;

    private void OnTriggerEnter(Collider other)
    {
        //TODO:被子弹打中后掉血
        if (other.gameObject.CompareTag("Bullet"))
        {
            BulletController bullet = other.gameObject.GetComponent<BulletController>();
            hp.OnAttack(bullet.Attack);
            Destroy(other.gameObject);
        }
    }
}
