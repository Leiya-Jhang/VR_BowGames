using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class FollowVR : MonoBehaviour
{ 
    private GameObject vrPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vrPlayer==null)
        {
            vrPlayer = GameObject.FindGameObjectWithTag("Agent");
        }
        Vector3 newPosition = new Vector3(vrPlayer.transform.position.x, vrPlayer.transform.position.y + 1.6f,
            vrPlayer.transform.position.z - 3f);
        transform.position = newPosition;
    }
}
