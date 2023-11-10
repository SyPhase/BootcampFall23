using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    AudioSource _SoundManager;

    void OnEnable()
    {
        _SoundManager = FindObjectOfType<AudioSource>();
    }

    void OnDisable()
    {
        _SoundManager.Play();
    }
}