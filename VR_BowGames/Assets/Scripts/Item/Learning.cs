using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Learning : MonoBehaviour
{
    [SerializeField] private GameObject VRplayer;
    [SerializeField] private GameObject networkManager;

    [SerializeField] private NetworkRunner runner;
    // [SerializeField] private NetworkObject networkObject;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (VRplayer == null)
        {
            VRplayer = GameObject.FindGameObjectWithTag("MainCamera");
            networkManager = GameObject.FindGameObjectWithTag("runner");
            runner = networkManager.GetComponent<NetworkRunner>();
            // networkObject = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<NetworkObject>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (runner.IsClient)
        {
        }
        else if (other.GetComponent<NetworkObject>().InputAuthority ==
                 networkManager.GetComponent<BasicSpawner>().selfPlayer)
        {
            VRplayer.GetComponent<VRCamera>().Inlearningarea();
        }
    }
}