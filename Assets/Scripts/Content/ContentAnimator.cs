using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentAnimator : MonoBehaviour, IContent
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ActivateContent()
    {
        if (_animator != null)
        {
            _animator.speed = 1f;
            _animator.Play(0, -1, 0f);
        }
    }

    public void DeactivateContent()
    {
        if (_animator != null)
        {
            _animator.Play(0, -1, 0f);
            _animator.speed = 0f;
        } 
    }
}
