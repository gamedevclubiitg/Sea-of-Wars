using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWeapon : MonoBehaviour
{
      private void OnTriggerEnter2D(Collider col)
         {
             if(col.gameObject.tag == "Player" && !col.gameObject.GetComponent<PlayerWeapon>().isEquipped)
             {  
                Debug.Log("collected "+gameObject.name);
                Destroy(gameObject);
                col.gameObject.GetComponent<PlayerWeapon>().isEquipped=true;
                col.gameObject.GetComponent<PlayerWeapon>().currentWeapon=gameObject;

             }
         }
}
