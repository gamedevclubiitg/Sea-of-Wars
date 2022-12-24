using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMultiPlayer : MonoBehaviour
{
    PhotonView PV;
    void Awake()
    {
        GameObject roomManager = GameObject.Find("RoomManager");
        PV = GetComponent<PhotonView>();
        if (PV.Controller == PhotonNetwork.MasterClient)
        {
            gameObject.layer = roomManager.GetComponent<RoomManager>().playerShootingLayer;
        }
        else
        {
            gameObject.layer = roomManager.GetComponent<RoomManager>().enemyShootingLayer;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        PhotonNetwork.Destroy(gameObject);
    }
   

}
