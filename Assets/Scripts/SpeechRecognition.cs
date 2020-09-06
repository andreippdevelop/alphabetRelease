using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class SpeechRecognition : MonoBehaviour
{
    [SerializeField] private Text _detectedWords;

    private const string _pluginName = "com.andrei.speechrecognition.AndroidSpeechRecognition";

    private AndroidJavaObject _androidJavaObject;

    public string DetectedWords
    {
        get
        {
            return _androidJavaObject.Call<string>("GetDetectedWords");
        }
    }

    private void Start()
    {
        _androidJavaObject = new AndroidJavaObject(_pluginName);
        Debug.Log("Android java object name "+_androidJavaObject.ToString());
    }

    public void StartRecognition()
    {
        _androidJavaObject.Call("StartRecognition");
    }

    public void StopRecognition()
    {
        _androidJavaObject.Call("StopRecognition");
    }

    private void Update()
    {
        _detectedWords.text = DetectedWords;
    }
}
