using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanTargetPage : PageUI
{
    [SerializeField] private Button _menuPageButton;

    private void OnEnable()
    {
        _menuPageButton.onClick.AddListener(GoToMenuPage);
        CustomTrackableEventHandler.OnTargetFound += GoToMainPage;
    }

    private void OnDisable()
    {
        _menuPageButton.onClick.RemoveAllListeners();
        CustomTrackableEventHandler.OnTargetFound -= GoToMainPage;
    }

    private void GoToMainPage()
    {
        if(PageController.CurrentActivePage.GetType()==typeof(ScanTargetPage))
            PageController.SwitchPageOn<MainPage>();
    }

    private void GoToMenuPage()
    {
        PageController.SwitchPageOn<ContactPage>();
    }
}
