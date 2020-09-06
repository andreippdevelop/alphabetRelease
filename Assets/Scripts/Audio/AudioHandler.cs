using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    protected float _delayInSeconds;

    protected bool _audioPlayIsFinished = false;
    public bool AudioPlayIsFinished => _audioPlayIsFinished;

    protected AudioSource _audioSource;
    protected Coroutine _playDescriptionCoroutine;

    public virtual void PlayTranslation()
    {

    }

    public virtual void Play()
    {
        Reset(true);
    }

    public virtual void Stop()
    {
        Reset();
    }

    protected virtual IEnumerator PlayDescriptionCoroutine()
    {
        yield return null;

        _audioPlayIsFinished = true;
    }

    private void Reset(bool playAfterReset = false)
    {
        _audioPlayIsFinished = false;

        if (_playDescriptionCoroutine != null)
            StopCoroutine(_playDescriptionCoroutine);

        if (playAfterReset)
            _playDescriptionCoroutine = StartCoroutine(PlayDescriptionCoroutine());
        else
            _audioSource.Stop();
    }
}
