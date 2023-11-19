using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Finds the AudioSource (on Sound Manager Game Object)
public class PlaySoundOnManager : MonoBehaviour
{
    // Must be set in Inspector
    [SerializeField] AudioClip soundToPlay;

    [Range(0f, 1f)] [SerializeField] float volume = 1f; // from 0 to 1

    // Cache Audio Source
    AudioSource audioSource;

    void Start()
    {
        // Get Audio Source on the SoundManager
        audioSource = FindObjectOfType<SoundManager>().GetComponent<AudioSource>();

        // Play Audio
        audioSource.PlayOneShot(soundToPlay, volume);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Play Audio
        audioSource.PlayOneShot(soundToPlay, volume);
    }
}