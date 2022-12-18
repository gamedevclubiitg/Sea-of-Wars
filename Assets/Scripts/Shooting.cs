using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting: MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float bulletForce = 100f;
    public Vector3 rotation = new Vector3(0, 0, 5);
   
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Shoot();
        }
        Movement();
    }
    void Shoot()
    {
        GameObject bullet=Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up*bulletForce,ForceMode2D.Impulse);
        bullet.layer = 9;

    }
    void Movement()
    {
        
        if (Input.GetKey("a"))
        {
            gameObject.transform.eulerAngles += rotation;
        }
        if(Input.GetKey("d"))
        {
            gameObject.transform.eulerAngles -= rotation;
        }
    }
}
