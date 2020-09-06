using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentAnimation : MonoBehaviour, IContent
{
    private Animation _animation;
    private Coroutine _stopAnimation;

    void Start()
    {
        _animation = GetComponent<Animation>();
    }

    public void ActivateContent()
    {
        if (_animation != null)
        {
            _animation.Rewind();
            _animation.Play();
        }
    }

    public void DeactivateContent()
    {
        if (_animation != null)
        {
            _animation.Rewind();

            if (_stopAnimation != null)
                StopCoroutine(_stopAnimation);

            _stopAnimation = StartCoroutine(StopAnimation());
        }
    }

    private IEnumerator StopAnimation()
    {
        yield return new WaitForEndOfFrame();
        _animation.Stop();
    }
}
