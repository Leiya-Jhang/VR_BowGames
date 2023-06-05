using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    private AudioSource audio;
    public AudioClip[] clips;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSpeed<=0)
        {
            audio.clip = clips[1];
            audio.Play();
        }
        else
        {
            audio.clip = clips[0];
            audio.Play();
        }
        transform.position += transform.forward*Time.deltaTime*moveSpeed;
        if (transform.position.x>=70)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.x<=-50)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.z>=50)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.z<=-35)
        {
            Destroy(this.gameObject);
        }
    }
}
