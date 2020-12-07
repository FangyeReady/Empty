using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
   // GameObject _Enemy;
    public GameObject _Targt;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(_Targt.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
