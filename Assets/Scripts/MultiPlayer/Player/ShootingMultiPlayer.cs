using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShootingMultiPlayer : MonoBehaviour
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
        GameObject bullet = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "BulletPrefabMultiPlayer"), firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up
            *bulletForce,ForceMode2D.Impulse);

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
