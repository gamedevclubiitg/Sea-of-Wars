using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMultiPlayer : MonoBehaviour
{
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
