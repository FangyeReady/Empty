using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class CreateBullet : MonoBehaviour
{
    public GameObject bulletPrefab;


    private void Awake()
    {
        StartCoroutine(CreateCube());
    }

    IEnumerator CreateCube()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                yield return new WaitForSeconds(1f);
                Instantiate(bulletPrefab, new Vector3(0, 1, 0), Quaternion.identity);
            }

            yield return null;
        }
    
    }



}
