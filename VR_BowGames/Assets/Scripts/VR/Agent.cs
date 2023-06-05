using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Random = System.Random;

public class Agent : NetworkBehaviour
{
    public AudioClip[] hint;
    private AudioSource audioSource;
    public Transform spawnPoint;
    [SerializeField] private NetworkCharacterControllerPrototype networkCharacterControllerPrototype = null;
    [SerializeField] private GameObject networkManager;
    [SerializeField] private NetworkRunner runner;
    [SerializeField] private NetworkObject networkObject;
    [SerializeField] private InputActionProperty buttoB;

    private void Start()
    {
        if (runner == null)
        {
            networkManager = GameObject.FindGameObjectWithTag("runner");
            audioSource = GetComponent<AudioSource>();
            runner = networkManager.GetComponent<NetworkRunner>();
            networkObject = GetComponent<NetworkObject>();
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out InputData data))
        {
            Vector3 moveVector3 = data.movementInput.normalized;
            float _rotate = data.rotate;
            networkCharacterControllerPrototype.Move(moveVector3 * Runner.DeltaTime * 15f);
            networkCharacterControllerPrototype.Rotate(_rotate);
        }
    }

    private void Update()
    {
        if (runner.LocalPlayer == networkObject.InputAuthority)
        {
            if (audioSource.isPlaying == false)
            {
                if (buttoB.action.IsPressed())
                {
                    Hint_Voice_Rpc();
                }
            }
        }
        
        if (spawnPoint == null)
        {
            spawnPoint = GameObject.FindWithTag("Point").transform;
        }

        if (networkCharacterControllerPrototype.transform.position.y <= -5f)
        {
            networkCharacterControllerPrototype.transform.position = spawnPoint.position;
        }
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void Hint_Voice_Rpc()
    {
        if (runner.IsClient)
        {
            if (audioSource.isPlaying == false)
            {
                int i = UnityEngine.Random.Range(0, 5);
                audioSource.clip = hint[i];
                audioSource.Play();
            }
        }
    }
}