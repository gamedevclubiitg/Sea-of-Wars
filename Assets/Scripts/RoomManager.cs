using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;
    public int gamelevel = 1;
    void Awake()
    {
    if(Instance)
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
    void OnSceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex==gamelevel)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"),Vector3.zero,Quaternion.identity);
        }
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
