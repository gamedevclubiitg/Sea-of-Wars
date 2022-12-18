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
        //dont touch this
    }
    public void PlayerControllerPosition()
    {
        int index = 0;
        foreach (Player pl in PhotonNetwork.PlayerList)
        {
            PV.RPC("InstantiationPlayer", pl, index);
            index++;
            
        }
        
    }
    [PunRPC]
    void InstantiationPlayer(int index)
    {
        GameObject roomManager = GameObject.Find("RoomManager");
        GameObject playerController = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), roomManager.GetComponent<RoomManager>().spawnPoints[index].position,Quaternion.Euler(0,0,index*180f));
        SetGameLayerRecursive(playerController, roomManager.GetComponent<RoomManager>().playerLayer + index);
        MenuManager.Instance.OpenMenu("game");
    }
    private void SetGameLayerRecursive(GameObject _go, int _layer)
    {
        _go.layer = _layer;
        foreach (Transform child in _go.transform)
        {
            child.gameObject.layer = _layer;

            Transform _HasChildren = child.GetComponentInChildren<Transform>();
            if (_HasChildren != null)
                SetGameLayerRecursive(child.gameObject, _layer);

        }
    }
}
