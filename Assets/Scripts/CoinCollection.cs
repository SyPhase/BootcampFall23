using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] float _volume = 1f;
    [SerializeField] AudioClip _pickupSFX;

    AudioSource _soundManager;

    void OnEnable()
    {
        _soundManager = FindObjectOfType<AudioSource>();
    }

    void OnDisable()
    {
        if (_soundManager)
        _soundManager.PlayOneShot(_pickupSFX, _volume);
    }
}