using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BasicSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
    public GameObject settingDeviceUI;
    public Transform spawnPoint;
    public GameObject _path;
    public GameObject firstCamera;
    private float speed = 0f;
    private float i = 0;
    private NetworkObject outnetNetworkObject;
    [SerializeField] private GameObject transGameObject;
    [SerializeField] private Transform handPos;
    [SerializeField] private InputActionProperty triggerAction;
    [SerializeField] private NetworkRunner networkRunner = null;
    [SerializeField] private NetworkPrefabRef prefabRef;
    [SerializeField] private Volume _volume;

    public PlayerRef selfPlayer;

    public Dictionary<PlayerRef, NetworkObject> playerList = new Dictionary<PlayerRef, NetworkObject>();

    private void Start()
    {
        settingDeviceUI.SetActive(true);
        StartGame(GameMode.AutoHostOrClient);
    }

    private void Update()
    {
        if (handPos == null || transGameObject == null)
        {
            handPos = GameObject.FindWithTag("Agent").transform.GetChild(1).transform.GetChild(1).transform;
            _volume = GameObject.FindWithTag("Agent").transform.GetChild(1).transform.GetChild(0).GetComponent<Volume>();
            transGameObject = GameObject.FindGameObjectWithTag("Rotation");
        }
        else
        {
            Debug.Log(handPos.transform.localPosition.x);
            if (handPos.transform.localPosition.x > 0.25f)
            {
                i += 1;
                transGameObject.transform.localEulerAngles = new Vector3(0, i, 0);
            }

            if (handPos.transform.localPosition.x < -0.25f)
            {
               
                i -= 1;
                transGameObject.transform.localEulerAngles = new Vector3(0, i, 0);
            }
        }

        if (triggerAction.action.IsPressed())
        {
            speed = 0.5f;
            _volume.enabled = true;
        }
        else
        {
            speed = 0f;
            _volume.enabled = false;
        }
    }

    async void StartGame(GameMode mode)
    {
        networkRunner.ProvideInput = true;

        await networkRunner.StartGame(new StartGameArgs()
        {
            GameMode = mode,
            SessionName = "Demo Room",
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 2f,
            spawnPoint.position.z);
        NetworkObject networkObject = runner.Spawn(prefabRef, spawnPosition, new Quaternion(0, 0, 0, 0), player);
        _path.SetActive(true);
        firstCamera.SetActive(false);
        selfPlayer = player;
        playerList.Add(player, networkObject);
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        if (playerList.TryGetValue(player, out NetworkObject networkObject))
        {
            runner.Despawn(networkObject);
            playerList.Remove(player);
        }
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        var data = new InputData();
        if (transGameObject == null)
        {
        }
        else
        {
            data.rotate = transGameObject.transform.rotation.y;
            data.movementInput += transGameObject.transform.forward * speed;
        }

        input.Set(data);
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }
}