using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMultiPlayer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    { 
        PhotonNetwork.Destroy(gameObject);
    }
}
