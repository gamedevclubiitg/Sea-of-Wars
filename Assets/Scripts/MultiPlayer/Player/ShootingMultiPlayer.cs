using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShootingMultiPlayer : MonoBehaviour
{
   [SerializeField] Transform firePoint;
    public GameObject bulletPrefab;
    private float bulletForce = 10f;
    public Vector3 rotation = new Vector3(0, 0, 5);
    PhotonView PV;
    [SerializeField]
    int shootingLayer;
    void Start()
    {
        shootingLayer=gameObject.layer+2;
        firePoint = gameObject.transform.GetChild(1).transform;
        PV = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (PV.IsMine)
        {
            if (Input.GetKeyDown("space"))
            {
                Shoot();
            }
            Movement();
        }
    }
    void Shoot()
    {
        GameObject bullet = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "BulletPrefabMultiPlayer"), firePoint.position, firePoint.rotation);
        bullet.layer=shootingLayer;
        Debug.Log(bullet.layer);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up
          * bulletForce, ForceMode2D.Impulse);
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
