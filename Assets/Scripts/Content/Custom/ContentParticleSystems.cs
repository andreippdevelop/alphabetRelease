using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentParticleSystems : MonoBehaviour, IContent
{
    [SerializeField] private ParticleSystem[] _particleSystems;

    public void ActivateContent()
    {
        foreach (ParticleSystem buf in _particleSystems)
        {
            buf.Play();
        }           
    }

    public void DeactivateContent()
    {
        foreach (ParticleSystem buf in _particleSystems)
        {
            buf.Stop();
            buf.Clear();
        }
            
    }
}
