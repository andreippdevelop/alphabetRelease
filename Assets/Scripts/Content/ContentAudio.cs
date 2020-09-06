using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentAudio : MonoBehaviour, IContent
{
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ActivateContent()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
    }

    public void DeactivateContent()
    {
        if (_audioSource != null)
        { 
            _audioSource.Stop();
        }
    }
}
