using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ContentAlphabetScale : MonoBehaviour, IContentAlphabet
{
    private float _scaleDuration = 1f;
    private Ease _easeScale = Ease.Linear;

    private Vector3 _scaleMax;
    private Vector3 _scaleMin;

    void Awake()
    {
        Vector3 localScale = transform.localScale;

        _scaleMin = localScale / 200f;
        _scaleMax = localScale;

        ResetContent();
    }

    public void ActivateContent()
    {
        transform.DOScale(_scaleMax, _scaleDuration).SetEase(_easeScale);
    }

    public void DeactivateContent()
    {
        transform.DOScale(_scaleMin, _scaleDuration).SetEase(_easeScale);
    }

    public void ResetContent()
    {
        transform.DOKill();
        transform.localScale = _scaleMin;
    }
}
