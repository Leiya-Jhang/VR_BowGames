using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Unity.VisualScripting;

public class VRCamera : MonoBehaviour
{
    [SerializeField] private GameObject networkManager;
    [SerializeField] private NetworkObject selfNetworkObject;
    [SerializeField] private NetworkRunner runner;

    private void Start()
    {
        if (runner==null)
        {
            networkManager = GameObject.FindGameObjectWithTag("runner");
            runner = networkManager.GetComponent<NetworkRunner>();
            selfNetworkObject = transform.parent.gameObject.transform.parent.gameObject.GetComponent<NetworkObject>();
            CameraSet();
        }

    }

    public void CameraSet()
    {
        if (selfNetworkObject.InputAuthority ==  runner.LocalPlayer)
        {
            gameObject.GetComponent<Camera>().enabled = true;
            gameObject.GetComponent<AudioListener>().enabled = true;
            Debug.Log(selfNetworkObject.InputAuthority);
            Debug.Log(runner.LocalPlayer);
        }
    }

    public void Inlearningarea()
    {
        gameObject.GetComponent<Camera>().cullingMask = 0;
        gameObject.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
    }
}