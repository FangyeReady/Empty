using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public float Base_Healthy = 5;
    public float Base_Maxhealthy = 5;
    public Image Base_HPimage;
    // Start is called before the first frame update
    void Start()
    {
     //   Base_HPimage = Resources.Load<Image>(Img/hp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Base_Healthy<=0)
        {
            Destroy(this.gameObject);
        }
        if (other.tag=="Enemy")
        {
            Base_Healthy--;
            Base_HPimage.fillAmount = Base_Healthy / Base_Maxhealthy;
        }
    }
}
