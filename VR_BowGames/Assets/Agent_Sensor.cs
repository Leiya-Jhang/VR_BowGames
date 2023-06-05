using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_Sensor : MonoBehaviour
{
    private bool is_block;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (is_block == false)
        {
            if (GetComponentInParent<CarMovement>().moveSpeed <= 15)
            {
                GetComponentInParent<CarMovement>().moveSpeed += 0.5f;
                Debug.Log(GetComponentInParent<CarMovement>().moveSpeed);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Agent" || other.tag == "Car")
        {
            is_block = true;
            if (GetComponentInParent<CarMovement>().moveSpeed > 0)
            {
                GetComponentInParent<CarMovement>().moveSpeed -= 0.5f;
                Debug.Log(GetComponentInParent<CarMovement>().moveSpeed);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

            is_block = false;
    }
}