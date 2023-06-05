using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVRCamera : MonoBehaviour
{
    public Transform mainCamera;

    private void Update()
    {
        Vector3 cameraPos = new Vector3(mainCamera.position.x, mainCamera.position.y * 0f, mainCamera.position.z);
        Quaternion cameraRota = new Quaternion(mainCamera.rotation.x * 0f, mainCamera.rotation.y, mainCamera.rotation.z,mainCamera.rotation.w);
        transform.position = cameraPos;
        transform.rotation = cameraRota;
    }
}
