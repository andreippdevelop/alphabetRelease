using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTargetControllerGenerall : MonoBehaviour, IMarkerControllerContent
{
    public AudioSource audioSource;
    public GameObject bodyObject;

    public void ActivateByTrackMarker()
    {
        if(audioSource!=null)
        {
            audioSource.Play();
        }

        if (bodyObject != null)
        {
            bodyObject.SetActive(true);
        }
    }

    public void DectivateByUnTrackMarker()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
        
        if(bodyObject != null)
        {
            bodyObject.SetActive(false);
        }       
    }
}
