using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ContentJumpRotate : MonoBehaviour, IContent
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _yValues = new Vector2(0f, 10f);
    [SerializeField] private float _durationJump = 1f;
    [SerializeField] private float _durationRotation = 1f;
    [SerializeField] private float _rotateDegree = -360f;
    [SerializeField] private Ease _ease;

    private Vector3 _defaultTargetPosition;

    private void Awake()
    {
        DOTween.defaultEaseType = _ease;
        _defaultTargetPosition = _target.localPosition;
    }

    public void ActivateContent()
    {
        Vector3 newRotateVector = new Vector3(transform.localEulerAngles.x + _rotateDegree, 0f, 0f);

        _target.DOLocalMoveY(_yValues.y, _durationJump).
                OnComplete(() => _target.DOLocalRotate(newRotateVector, _durationRotation, RotateMode.FastBeyond360).
                OnComplete(() => _target.DOLocalMoveY(_yValues.x, _durationJump)));
    }

    public void DeactivateContent()
    {
        DOTween.KillAll(true);
        _target.localPosition = _defaultTargetPosition;
    }
}
