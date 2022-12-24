using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMultiPlayer : MonoBehaviour
{
    PhotonView PV;
    public Image FillImage;

    private void Start()
    {
        PV= GetComponent<PhotonView>(); 
    }
    [PunRPC]void ReduceHealth(float amount)
    {
        
        ModifyHealth(amount);
    }
    void ModifyHealth(float amount)
    {
        
        if (!PV.IsMine)
            return;
        Debug.Log(FillImage.fillAmount + "before");
        FillImage.fillAmount -= amount;
        Debug.Log(FillImage.fillAmount);
    }
}
