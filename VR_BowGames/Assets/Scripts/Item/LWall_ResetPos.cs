using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LWall_ResetPos : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            other.transform.position = new Vector3(-4f, other.transform.position.y, other.transform.position.z);
            Debug.Log("Is trigger");
        }
    }
}
