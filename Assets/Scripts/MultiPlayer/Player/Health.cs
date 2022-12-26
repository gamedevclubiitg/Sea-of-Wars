using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    Image FillImage;
    public float MaxHealth = 100;
    [SerializeField] float currentHealth;
    PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        FindHealthBar();
        currentHealth=MaxHealth;
        PV= GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FindHealthBar()
    {
            GameObject tempCanvas = gameObject.transform.GetChild(0).gameObject;
            Image outlineImage = tempCanvas.transform.GetChild(0).GetComponentInChildren<Image>();
            FillImage = outlineImage.transform.GetChild(0).GetComponentInChildren<Image>();  
    }

    //health RPC
    [PunRPC]
    void ReduceHealth(float amount)
    {

        ModifyHealth(amount);
    }

    void ModifyHealth(float amount)
    {
        currentHealth -= amount;
        FillImage.fillAmount = currentHealth / 100;
    }



}
