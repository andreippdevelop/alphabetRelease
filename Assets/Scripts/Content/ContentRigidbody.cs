using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentRigidbody : MonoBehaviour, IContent
{
    public void ActivateContent()
    {
        SwitchGravity(true);
    }

    public void DeactivateContent()
    {
        SwitchGravity(false);
    }

    public void SwitchGravity(bool value)
    {
        var rigidbodyComponents = GetComponentsInChildren<Rigidbody>(true);
        foreach (Rigidbody buf in rigidbodyComponents)
        {
            buf.useGravity = value;
        }
    }
}
