using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMultiPlayer : MonoBehaviour
{
    public float damage = 10f;
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
        PhotonView target = collision.GetComponent<PhotonView>();
        foreach(Player pl in PhotonNetwork.PlayerList)
        {
            if (pl.IsLocal == true)
                continue;
            if(pl.IsLocal==false)
            {
                PV.RPC("ReduceHealth",pl,damage,collision.tag);
                break;
            }
        }
        PhotonNetwork.Destroy(gameObject);
    }
}
