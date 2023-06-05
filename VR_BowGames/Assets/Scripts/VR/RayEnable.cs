using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class RayEnable : MonoBehaviour
{
    [SerializeField] private GameObject networkManager;
    [SerializeField] private NetworkRunner runner;
    [SerializeField] private NetworkObject networkObject;

    // Start is called before the first frame update
    void Start()
    {
        if (runner == null)
        {
            networkManager = GameObject.FindGameObjectWithTag("runner");
            runner = networkManager.GetComponent<NetworkRunner>();
            networkObject = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<NetworkObject>();
        }

        Ray();
    }
    public void Ray()
    {
        if (networkObject.InputAuthority == runner.LocalPlayer)
        {
            if (runner.IsClient)
            {
                gameObject.SetActive(false);
                Debug.Log("Ray_close_Client");
            }
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("Ray_Close");
        }
    }
}