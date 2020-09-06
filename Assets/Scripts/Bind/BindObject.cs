using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BindObject : MonoBehaviour, IMarkerControllerContent
{
    [SerializeField] private float _rebindDefaultDelay = 1f;

    private Vector3 _startLocalPosition = Vector3.zero;
    private Quaternion _startLocalRotation = Quaternion.identity;
    private Rigidbody _rigidbody;

    private Coroutine _rebind;

    private float _minScale = 0f;
    private float _originalScale = 1f;
    private float _scaleDuration = 0.5f;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _startLocalPosition = transform.localPosition;
        _startLocalRotation = transform.localRotation;
        _rigidbody = GetComponent<Rigidbody>();

        _originalScale = transform.localScale.x;
    }

    public void Rebind(bool immediately = false)
    {
        if(_rebind != null)
        {
            StopCoroutine(_rebind);
        }

        float delay = (immediately) ? 0 : _rebindDefaultDelay;

        _rebind = StartCoroutine(RebindCoroutine(delay));
    }

    private IEnumerator RebindCoroutine(float delay)
    {
        transform.DOScale(_minScale, _scaleDuration);

        yield return new WaitForSeconds(delay);

        transform.DOScale(_originalScale, _scaleDuration);
        ResetPositionRotation();
    }

    private void ResetPositionRotation()
    {
        transform.localPosition = _startLocalPosition;
        transform.localRotation = _startLocalRotation;

        _rigidbody.velocity = Vector3.zero;
    }

    public void ActivateByTrackMarker()
    {
        Rebind(true);
    }

    public void DectivateByUnTrackMarker()
    {
        Rebind(true);
    }
}
