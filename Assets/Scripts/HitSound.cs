using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public AudioClip aud;
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = aud;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<AudioSource>().Play();
    }
}
