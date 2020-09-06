using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class TutorialPage : PageUI
{
    public const string PRIVACY_POLICY_APPLY = "PrivacyPolicyApply";

    [SerializeField] private HorizontalScrollSnap _scrollSnap;
    [SerializeField] private Button _okButton;

    public override void SetActivate(bool value, params object[] parameters)
    {
        base.SetActivate(value, parameters);

        if(value)
        {
            Show();
            _okButton.onClick.AddListener(ApplyPrivacyPolicy);
        }
        else
        {
            _okButton.onClick.RemoveAllListeners();
        }
    }

    public void Show()
    {
       _scrollSnap._currentPage = 0;
       _scrollSnap.UpdateLayout();
       _scrollSnap.SetCurrentPage();
    }

    private void ApplyPrivacyPolicy()
    {
        PlayerPrefs.SetInt(TutorialPage.PRIVACY_POLICY_APPLY, 1);
        PageController.SwitchPageOn<ScanTargetPage>();
    }
}