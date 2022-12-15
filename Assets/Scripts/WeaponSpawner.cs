using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
 public GameObject[] item;
    
    public float delay = 3f;
    float radius = 0.01f;
    bool spawnCalled=false;
    Vector3 spawnPos;

    void Start() {
        spawnPos=transform.position;
        
    }
   
    

    // Update is called once per frame
    void Update()
    {
        if (!Physics2D.OverlapCircle(spawnPos, radius) && !spawnCalled) {
        // found something
        Invoke(nameof(Spawn),delay);
        spawnCalled=true;
        }
      
       
        
    }

   
    public void Spawn(){

        GameObject newSpawn = Instantiate(item[Random.Range(0,2)],transform.position,Quaternion.identity);
        newSpawn.transform.parent = transform;
        //newSpawn.getComponent <DeSpawner> ().MySpawnSlot = this;
        spawnCalled=false;
    }
}
