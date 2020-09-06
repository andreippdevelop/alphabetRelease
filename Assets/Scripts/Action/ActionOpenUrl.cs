using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionOpenUrl : MonoBehaviour, IAction
{
    [SerializeField] private string _url;

    public void DoTheAction()
    {
        Application.OpenURL(_url);
    }
}
