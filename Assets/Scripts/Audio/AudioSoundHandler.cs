using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSoundHandler : AudioHandler
{
    private AudioClip[] _sounds;

    public void Initilize(AudioSource audioSource, float delay, AudioClip[] sounds)
    {
        base._audioSource = audioSource;
        base._delayInSeconds = delay;
        _sounds = sounds;
    }

    protected override IEnumerator PlayDescriptionCoroutine()
    {
        //Play All Audio Descriptions
        for (int i = 0; i < _sounds.Length; i++)
        {
            _audioSource.clip = _sounds[i];

            if (_audioSource.clip != null)
            {
                _audioSource.Play();
                yield return new WaitForSeconds(_audioSource.clip.length + _delayInSeconds);
            }
            else
            {
                yield return null;
            }
        }

        _audioPlayIsFinished = true;
    }
}
