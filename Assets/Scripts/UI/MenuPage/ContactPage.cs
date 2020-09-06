using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactPage : PageUI
{
    [SerializeField] private Button _backButton;


    private void OnEnable()
    {
        _backButton.onClick.AddListener(GoBack);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveAllListeners();
    }

    private void GoBack()
    {
        PageController.SwitchPageBack();
    }
}
