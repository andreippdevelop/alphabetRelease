using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ScanTargetStopTracking : MonoBehaviour
{
    private ObjectTracker _tracker;

    private void InitilaizeIfNeed()
    {
        if(_tracker == null)
            _tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
    }

    //private void OnEnable()
    //{
    //    DisableAudioSignalOnEnable.OnDisableAudioSignal += SwitchTracking;
    //}

    //private void OnDisable()
    //{
    //    DisableAudioSignalOnEnable.OnDisableAudioSignal -= SwitchTracking;
    //}

    public void SwitchTracking(bool value)
    {
        StartCoroutine(SwitchWithDelay(value));
    }

    private IEnumerator SwitchWithDelay(bool value)
    {
        yield return new WaitForSeconds(1f);
        InitilaizeIfNeed();

        if (!value)
            StartTracking();
        else
            StopTracking();
    }

    private void StopTracking()
    {
        if (_tracker != null && _tracker.IsActive)
        {
            Debug.Log("************************************************************************Stop tracking");
            _tracker.Stop();
        }
    }

    private void StartTracking()
    {
        if (_tracker != null && !_tracker.IsActive)
        {
            Debug.Log("************************************************************************Start tracking");
            _tracker.Start();
        }
    }
}
