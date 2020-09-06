using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlateController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        BindObject bindObject = other.GetComponent<BindObject>();
        Debug.Log("-----------------------TRIGGER");
        if (bindObject!=null)
        {
            Debug.Log("BindObject-----------------------BindObject");
            bindObject.Rebind();
        }
    }
}
