using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionMailWrite : MonoBehaviour, IAction, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private string _mailAdress;

    public void DoTheAction()
    {
        Application.OpenURL("mailto:" + _mailAdress + "?subject=" + "&body=");
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        DoTheAction();
    }
}
