using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Step : MonoBehaviour
{
    private bool is_Guidebrick = false;
    [SerializeField] private InputActionProperty left_Trigger;
    [SerializeField] public AudioClip[] step;

    private void Update()
    {
        if (left_Trigger.action.IsPressed())
        {
            if (GetComponent<AudioSource>().isPlaying == false)
            {
                GetComponent<AudioSource>().Play();
                Debug.Log("Audio = " + GetComponent<AudioSource>().isPlaying);
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
            Debug.Log("Audio = " + GetComponent<AudioSource>().isPlaying);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brick")
        {
            is_Guidebrick = true;
            GetComponent<AudioSource>().clip = step[0];
            Debug.Log(other.tag);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Brick")
        {
            is_Guidebrick = false;
            Debug.Log(other.tag);
        }
    }
}