using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;
    public int gamelevel = 1;
    public Transform[] spawnPoints;
    public Button button;
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public override void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        base.OnDisable();
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == gamelevel)
        {
            GameObject instance = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            if (instance.GetComponent<PhotonView>().Controller == PhotonNetwork.MasterClient) ;
            {
                Button _button = button.GetComponent<Button>();
                _button.onClick.AddListener(instance.GetComponent<PlayerManager>().PlayerControllerPosition);
            }

        }
    }
    void Start()
    {


    }
    void Update()
    {

    }
}
