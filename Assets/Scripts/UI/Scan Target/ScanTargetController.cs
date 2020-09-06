//using CaptureShare;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanTargetController : PageUIController
{
    //[SerializeField] private ScanTargetStopTracking _scanTargetStopTracking;
    //[SerializeField] private CaptureAndShare _captureAndShare;
    //[SerializeField] private GameObject _rawImage;
    //private Coroutine _goToScanTargetStepCoroutine;

    private void OnEnable()
    {
        CustomTrackableEventHandler.OnTargetLost += GoToScanTargetPageStep;
    }

    private void OnDisable()
    {
        CustomTrackableEventHandler.OnTargetLost -= GoToScanTargetPageStep;
    }

    private void GoToScanTargetPageStep()
    {
        //if(_captureAndShare.IsVideoCaptureStarted)
        //{
        //    _captureAndShare.CaptureVideoEnd();
        //    GoToScanTargetStepWithDelay(0.5f);
        //    _scanTargetStopTracking.SwitchTracking(true);
        //}
        //else if (!_rawImage.activeInHierarchy)
        //{
        if (CurrentActivePage != null && CurrentActivePage.GetType() == typeof(MainPage))
            SwitchPageOn<ScanTargetPage>();
        //}           
        //else
        //{
        //    GoToScanTargetStepWithDelay();
        //}
    }

    //private void GoToScanTargetStepWithDelay(float additionallyDelay = 0f)
    //{
    //    if (_goToScanTargetStepCoroutine == null)
    //        _goToScanTargetStepCoroutine = StartCoroutine(GoToScanTargetStepCoroutine(additionallyDelay));
    //    else
    //    {
    //        StopCoroutine(_goToScanTargetStepCoroutine);
    //        _goToScanTargetStepCoroutine = StartCoroutine(GoToScanTargetStepCoroutine(additionallyDelay));
    //    }
    //}

    //private IEnumerator GoToScanTargetStepCoroutine(float additionallyDelay = 0f)
    //{
    //    yield return new WaitForSeconds(additionallyDelay);
    //    yield return new WaitUntil(() => !_rawImage.activeInHierarchy);
    //    SwitchPageOn<ScanTargetStep>();
    //}

    void Start()
    {
        #if UNITY_EDITOR
                SwitchPageOn<TutorialPage>();
        #else
                int skipPrivacyPolicy = PlayerPrefs.GetInt(TutorialPage.PRIVACY_POLICY_APPLY, 0);
                if (skipPrivacyPolicy == 0)
                {
                    SwitchPageOn<TutorialPage>();
                }
                else
                {
                    SwitchPageOn<ScanTargetPage>();
                }
        #endif
     }
}
