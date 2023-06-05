using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject goal;

    public Transform checkPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Agent")
        {
            SetPosition(other);
            Debug.Log("rotation");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        goal.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
    }

    private void SetPosition(Collider other)
    {
        other.transform.position = checkPosition.position;
        other.transform.rotation = checkPosition.rotation;
    }
}
