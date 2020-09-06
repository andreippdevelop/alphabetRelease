using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTargetController : MonoBehaviour, IMarkerControllerContent
{
    public TargetObjectDescription[] descriptions;
    public AudioClip[] sounds;
    public GameObject alphabetSymbol;
    public Color symbolColor = Color.white;

    [SerializeField] private Button _translateButton;
    [SerializeField] private float _delayInSecondsBetweenAudioSound = 0f;
    private float _delayInSecondsBetweenAudio = 1f;
    private float _delayInSecondsContentAlphabet = 3f;

    private AudioDescriptionHandler _audioDescriptionHandler;
    private AudioSoundHandler _audioSoundHandler;
    private AudioSource _audioSource;
    private Coroutine _activationCoroutine;
    private IContent[] _contents;
    private IContentAlphabet _contentAlphabet;
    private IContentMainBody _contentMainBody;

    void Awake()
    {
        Initialization();
    }

    private void Initialization()
    {
        _audioDescriptionHandler = gameObject.AddComponent<AudioDescriptionHandler>();
        _audioSoundHandler = gameObject.AddComponent<AudioSoundHandler>();
        _audioSource = gameObject.AddComponent<AudioSource>();

        _audioDescriptionHandler.Initilize(_audioSource, _delayInSecondsBetweenAudio, descriptions);
        _audioSoundHandler.Initilize(_audioSource, _delayInSecondsBetweenAudio, sounds);

        _contents = GetComponentsInChildren<IContent>();
        _contentAlphabet = GetComponentInChildren<IContentAlphabet>();
        _contentMainBody = GetComponentInChildren<IContentMainBody>();
    }

    public void ActivateByTrackMarker()
    {
        Reset(true);
        _translateButton.onClick.AddListener(_audioDescriptionHandler.PlayTranslation);
    }

    public void DectivateByUnTrackMarker()
    {
       Reset();
        _translateButton.onClick.RemoveAllListeners();
    }

    private IEnumerator ActivationCoroutine()
    {
        _audioDescriptionHandler.Play();

        _contentAlphabet.ActivateContent();
        yield return new WaitForSeconds(_delayInSecondsContentAlphabet);
        _contentAlphabet.DeactivateContent();

        _contentMainBody.ActivateContent();

        yield return new WaitUntil(() => _audioDescriptionHandler.AudioPlayIsFinished);

        SetActiveContents(true);

        yield return new WaitForSeconds(_delayInSecondsBetweenAudioSound);

        _audioSoundHandler.Play();

        yield return new WaitUntil(() => _audioSoundHandler.AudioPlayIsFinished);
        
        // SetActiveContents(false);
    }

    private void SetActiveContents(bool value)
    {
        if (value)
        {
            foreach (IContent buf in _contents)
            {
                buf.ActivateContent();
            }
        }
        else
        {
            foreach (IContent buf in _contents)
            {
                buf.DeactivateContent();
            }
        }
    }

    private void Reset(bool activateAfterReset = false)
    {
        _contentMainBody.ResetContent();
        _contentAlphabet.ResetContent();

        SetActiveContents(false);

        if (_activationCoroutine != null)
            StopCoroutine(_activationCoroutine);

        if (activateAfterReset)
            _activationCoroutine = StartCoroutine(ActivationCoroutine());
        else
        {
            _audioDescriptionHandler.Stop();
            _audioSoundHandler.Stop();
        }
    }
}
