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
    void onTriggerEnter2D(Collision2D collision)
    {
        Debug.Log("hello Im from on Trigger");
        PhotonNetwork.Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hello Im from oon entee collision2d");
        PhotonNetwork.Destroy(gameObject);
    }

}
