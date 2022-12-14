using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] GameObject[] GunHolders;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("hello I'm fron 1");
            ShootingAttach(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShootingAttach(2);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShootingAttach(3);
        }
    }
    void ShootingAttach(int num)
    {
        for(int i = 0; i < GunHolders.Length; i++)
        {
            Shooting childScript= GunHolders[i].GetComponentInChildren<Shooting>();
          
           if(i+1==num)
            {
                childScript.enabled = true;
            }
            else
            {
                childScript.enabled = false;
            }
        }

       

    }
}
