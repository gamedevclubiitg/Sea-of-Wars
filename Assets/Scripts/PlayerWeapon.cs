using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
   public bool isEquipped;
   
   public GameObject currentWeapon;

   void Update() {
      if(Input.GetKeyDown(KeyCode.Space) && isEquipped){
      
      Debug.Log("weapon fired");
      isEquipped=false;
      }

   }
   

   
   
}
