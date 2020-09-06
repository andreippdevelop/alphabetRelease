using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPage : PageUI
{
    [SerializeField] private Button _menuPageButton;


    private void OnEnable()
    {
        _menuPageButton.onClick.AddListener(GoToMenuPage);
    }

    private void OnDisable()
    {
        _menuPageButton.onClick.RemoveAllListeners();
    }

    private void GoToMenuPage()
    {
        PageController.SwitchPageOn<ContactPage>();
    }
}
