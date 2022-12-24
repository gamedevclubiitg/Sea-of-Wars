using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMultiPlayer : MonoBehaviour
{
    public float damage = 0.01f;
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
        if (!PV.IsMine)
            return;
        PhotonView target=collision.gameObject.GetComponent<PhotonView>();  

        if(target!= null&&(!target.IsMine||target.IsRoomView))
        {
            target.RPC("ReduceHealth",RpcTarget.AllBuffered, damage) ;
        }
        PhotonNetwork.Destroy(gameObject);
    }
   

}
