using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ContentVideo : MonoBehaviour, IContent
{
    [SerializeField] private RenderTexture _rendTexture;

    private const float DELAY_BEFORE_RESTART_VIDEO = 1.5f;

    private VideoPlayer _videoPlayer;
    private AudioSource _audioSource;
    private bool _restartFromBegin = true;

	void Start ()
    {
       _videoPlayer = GetComponent<VideoPlayer>();
        _audioSource = GetComponent<AudioSource>();
	}

    public void ActivateContent()
    {
        if (_videoPlayer != null/* &&  !DisableAudioSignalOnEnable.IsDisabled*/)
        {           
            Debug.Log("---------------------------------------------------------------------Activate Content");
            if (_restartFromBegin)
            {
                _videoPlayer.Stop();
                _rendTexture.Release();
            }
            _videoPlayer.Play();
            _audioSource.mute = false;
        }
    }

    public void DeactivateContent()
    {
        if (_videoPlayer != null)
        {
            Debug.Log("---------------------------------------------------------------------Deactivate Content");
            StopAllCoroutines();
            StartCoroutine(DelayBeforeRestart());

            _videoPlayer.Pause();
            _audioSource.mute = true;
        }
    }

    private IEnumerator DelayBeforeRestart()
    {
        _restartFromBegin = false;
        yield return new WaitForSeconds(DELAY_BEFORE_RESTART_VIDEO);
        _restartFromBegin = true;
    }
}
