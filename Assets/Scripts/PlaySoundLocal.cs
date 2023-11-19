using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Needs an AudioSource Component on this Object
public class PlaySoundLocal : MonoBehaviour
{
    // Cache Audio Source
    AudioSource audioSource;

    void Start()
    {
        // Get Audio Source
        audioSource = GetComponent<AudioSource>();

        // Play Audio
        audioSource.Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Play Audio
        audioSource.Play();
    }
}