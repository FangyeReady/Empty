using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class EffectController : MonoBehaviour
{
    public AudioSource source;

    private void Awake()
    {
        Destroy(this.gameObject, 1.5f);


        source.Play();
    }



}
