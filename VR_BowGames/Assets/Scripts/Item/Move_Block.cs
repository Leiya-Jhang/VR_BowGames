using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Block : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            other.transform.Translate(-other.transform.forward*0.5f);
            Debug.Log("Is trigger");
        }
    }
}
