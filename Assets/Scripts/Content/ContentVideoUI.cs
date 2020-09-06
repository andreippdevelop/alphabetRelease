using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ContentVideoUI : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    private RawImage _rawImage;

    void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _rawImage = GetComponent<RawImage>();
    }

    void Start()
    {
        InitializeVideo();
    }

    public void InitializeVideo()
    {
        StartCoroutine(InitializeVideoWithDelay(true));
    }

    private IEnumerator InitializeVideoWithDelay(bool pause)
    {
        _videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!_videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        _rawImage.texture = _videoPlayer.texture;
        _videoPlayer.SetDirectAudioVolume(1, 0f);
        yield return new WaitForEndOfFrame();
        _videoPlayer.Play();

        if (pause)
        {
            yield return new WaitForSeconds(0.25f);
            _videoPlayer.Pause();
            _videoPlayer.SetDirectAudioVolume(1, 1f);
        }
    }

    public void PlayVideo()
    {
        StartCoroutine(InitializeVideoWithDelay(false)); 
    }

    public void StopVideo()
    {
        _videoPlayer.Stop();
    }
}
