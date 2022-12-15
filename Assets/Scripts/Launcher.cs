using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;
    [SerializeField] TMP_InputField createRoomInputField;
    [SerializeField] TMP_InputField nickNameInputField;
    [SerializeField] TMP_InputField joinRoomInputField;
    [SerializeField] Toggle toggleInput;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text disconnectedText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] TMP_Text nickNameText1;
    [SerializeField] TMP_Text nickNameText2;
    [SerializeField] Transform roomListContent;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] GameObject playerListItemPrefab;
    [SerializeField] GameObject startGameButton;
    
    //room options
    public byte maxPlayers=2;
    RoomOptions roomOptions;
    //gamelevel
    public int gamelevel = 1;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PhotonNetwork.NickName="Player"+Random.Range(0,1000).ToString();
        nickNameText1.text="PlayerName: "+PhotonNetwork.NickName;
        nickNameText2.text="PlayerName: "+PhotonNetwork.NickName;
    }
   
    public void ConnectToServer()
    {
        StartCoroutine(ConnectAndLoad());
    }
    IEnumerator ConnectAndLoad()
    {
        PhotonNetwork.ConnectUsingSettings();
        while (PhotonNetwork.NetworkingClient.LoadBalancingPeer.PeerState.ToString()=="Connecting")
        {
            MenuManager.Instance.OpenMenu("loading");
            yield return null;
        }
        Debug.Log("Connecting to the master");

    }

    public override  void OnDisconnected(DisconnectCause cause)
    {

        if (cause.ToString() == "DisconnectByClientLogic")
            MenuManager.Instance.OpenMenu("offline");
        else
        {
            disconnectedText.text ="Disconnected due to "+cause.ToString();
            MenuManager.Instance.OpenMenu("disconnect");
        }
    }
    public void ReconnectPlayer()
    {
        StartCoroutine(ReconnctAndLoad());
    }
    IEnumerator ReconnctAndLoad()
    {
        while(!(PhotonNetwork.NetworkingClient.LoadBalancingPeer.PeerState.ToString()=="Disconnected"))
        {
            MenuManager.Instance.OpenMenu("loading");
            yield return null;
        }
        PhotonNetwork.Reconnect();
    }
    public void DisconnectPlayer()
    {
        StartCoroutine(DisconnectAndLoad());
    }
    IEnumerator DisconnectAndLoad()
    {
        PhotonNetwork.Disconnect();
        while(!(PhotonNetwork.NetworkingClient.LoadBalancingPeer.PeerState.ToString()=="Disconnected"))
        {
            MenuManager.Instance.OpenMenu("loading");
            yield return null;
        }
        MenuManager.Instance.OpenMenu("offline");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("title");
        Debug.Log("Joined Lobby");
    }
    //Nickname
    public void OnSaveName()
    {
        if (string.IsNullOrEmpty(nickNameInputField.text))
        {
            return;
        }
        MenuManager.Instance.OpenMenu("title");
    }
    public void CreateRoom()
    {
        bool publicRoom;
        if(string.IsNullOrEmpty(createRoomInputField.text))
        {
            return;
        }
        if(toggleInput.isOn==true)
        {
            publicRoom = true;
        }
        else
        {
            publicRoom = false;
        }
        roomOptions = new RoomOptions() { IsVisible = publicRoom,IsOpen=true,MaxPlayers = maxPlayers };
        PhotonNetwork.CreateRoom(createRoomInputField.text, roomOptions, TypedLobby.Default);
        MenuManager.Instance.OpenMenu("loading");
    }
    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("loading");
      
    }
    public void JoinRoom()
    {
        if (string.IsNullOrEmpty(joinRoomInputField.text))
        {
            return;
        }

        PhotonNetwork.JoinRoom(joinRoomInputField.text);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        errorText.text = "Joining Room Failed: " + message;
        MenuManager.Instance.OpenMenu("error");
    }
    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        Player[] players = PhotonNetwork.PlayerList;
        foreach(Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
    
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text="Room creation failed: "+message;
        MenuManager.Instance.OpenMenu("error");
    }
    public void StartGame()
    {
        
        roomOptions.IsVisible = false;
        roomOptions.IsOpen = false;
        PhotonNetwork.LoadLevel(gamelevel);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }
        for(int i = 0; i < roomList.Count; i++)
        {
            if(roomList[i].RemovedFromList)
            {
                continue;
            }
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }
}
