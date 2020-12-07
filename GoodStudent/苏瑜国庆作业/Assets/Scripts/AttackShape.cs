using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySelf());
    }
    IEnumerator DestroySelf() {
        yield return null;
        Destroy(this.gameObject);
    }
}
