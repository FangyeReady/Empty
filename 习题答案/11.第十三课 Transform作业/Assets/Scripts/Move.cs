using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class Move : MonoBehaviour
{
    [Range(1, 100)]
    public float moveSpeed = 10f;
    public float addSpeed = 1f;
    public float speedRadio = 2f;
    public float rotateSpeed = 30f;
    float targetSpeed = 0;

    float fastFireTime = 0.1f;
    float timeGo = 0f;

    public GameObject bulltePrefab;
    public GameObject bulletSpawnPoint;
    public GameObject bulletContainer;

    private void Update()
    {
        Fire();
        ControllMove();
        
    }

    private void ControllMove()
    {

        if (Input.GetKey("left shift"))
        {
            addSpeed += Time.deltaTime * speedRadio; 
            addSpeed = Mathf.Min(addSpeed, 10);

        }
        else
        {
            addSpeed -= Time.deltaTime * speedRadio * 2;
            addSpeed = Mathf.Max(0, addSpeed);
        }
        targetSpeed = moveSpeed + addSpeed;



        float xOffet = Input.GetAxis("Horizontal");
        float yOffset = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xOffet * Time.deltaTime * targetSpeed, 0, yOffset * Time.deltaTime * targetSpeed);

        //第一种移动
      //  this.transform.Translate(direction, Space.Self);
       // return;

        //第二种移动
        float angle = xOffet * Time.deltaTime * rotateSpeed;
        this.transform.Rotate(Vector3.up, angle);
      
        if (xOffet != 0)
        {
            return;
        }

        //if (Input.GetKey(KeyCode.A))
        //{
        //    this.transform.Translate(Vector3.left * Time.deltaTime * targetSpeed, Space.Self);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    this.transform.Translate(Vector3.right * Time.deltaTime * targetSpeed, Space.Self);

        //}

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * targetSpeed, Space.Self);

        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * targetSpeed, Space.Self);
        }

    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBullet();
        }

        timeGo += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (timeGo >= fastFireTime)
            {
                CreateBullet();
                timeGo = 0f;
            }

        }
    }

    private void CreateBullet()
    {
        GameObject item = GameObject.Instantiate(bulltePrefab, bulletSpawnPoint.transform);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.transform.SetParent(bulletContainer.transform);
    }
}
