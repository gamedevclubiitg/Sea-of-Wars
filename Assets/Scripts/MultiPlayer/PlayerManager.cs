using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        
        if (PhotonNetwork.IsMasterClient)
        {
            PlayerControllerPosition();
        }
        Debug.Log(PhotonNetwork.IsMasterClient + " "+PhotonNetwork.MasterClient);
    }

    void PlayerControllerPosition()
    {
        int index = 0;
        foreach (Player pl in PhotonNetwork.PlayerList)
        {
            Debug.Log("hello PlayerControl Position Called");
            PV.RPC("InstantiationPlayer", pl, index);
            index++;
        }
    }
    [PunRPC]
    void InstantiationPlayer(int index)
    {
        GameObject roomManager = GameObject.Find("RoomManager");
      //  PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), roomManager.GetComponent<RoomManager>().spawnPoints[index].position,Quaternion.Euler(0,0,index*180f));
    }
}
