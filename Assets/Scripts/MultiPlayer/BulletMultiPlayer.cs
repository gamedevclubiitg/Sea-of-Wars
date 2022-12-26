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
        PV = GetComponent<PhotonView>();
        if (PV.Controller == PhotonNetwork.MasterClient)
        {
            gameObject.layer = RoomManager.Instance.playerShootingLayer;
        }
        else
        {
            gameObject.layer = RoomManager.Instance.enemyShootingLayer;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PhotonView target = collision.GetComponent<PhotonView>();
        if (target != null && (!target.IsMine || !target.IsRoomView))
        {
            target.RPC("ReduceHealth", RpcTarget.AllBuffered, damage);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
