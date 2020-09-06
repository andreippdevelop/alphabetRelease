using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioDescriptionHandler : AudioHandler
{
    private TargetObjectDescription[] _descriptions;
    private Transform _playTranslationPlace;

    public void Initilize(AudioSource audioSource, float delay, TargetObjectDescription[] descriptions)
    {
        base._audioSource = audioSource;
        base._delayInSeconds = delay;
        _descriptions = descriptions;
    }

    private void Start()
    {
        _playTranslationPlace = Camera.main.transform;
    }

    public override void PlayTranslation()
    {
        System.Func<TargetObjectDescription, bool> predicateLanguage;

        if (Application.systemLanguage == SystemLanguage.Ukrainian)
        {
            predicateLanguage = x => x.type == Language.LanguageType.Ukraine;   
        }
        else if (Application.systemLanguage == SystemLanguage.Russian)
        {
            predicateLanguage = x => x.type == Language.LanguageType.Russian;
        }
        else
        {
            predicateLanguage = x => x.type == Language.LanguageType.English;
        }

        AudioClip clip = _descriptions.Single(predicateLanguage).audioDescription;

        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, _playTranslationPlace.position);
        }
    }

    protected override IEnumerator PlayDescriptionCoroutine()
    {
        //Play All Audio Descriptions
        if(_descriptions.Length == 1)
        {
            _audioSource.clip = _descriptions[0].audioDescription;

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
        else if (_descriptions.Length > 1)
        {
            for (int i = 0; i < 2; i++)//_descriptions.Length; i++)
            {
                _audioSource.clip = _descriptions[i].audioDescription;

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
        }
       

        _audioPlayIsFinished = true;
    }
}
