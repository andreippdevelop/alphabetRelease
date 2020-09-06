using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private LoadingCircle _loadingCircle;
    private float _loadWaitTime = 6f;
    private float _vuforiaActivationTime = 2.5f;

    public void Awake()
    {
        DontDestroyOnLoad(this);
        Screen.sleepTimeout = SleepTimeout.NeverSleep; 
    }

    private IEnumerator Start()
    {
        _loadingCircle.StartLoading();
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync("Main", LoadSceneMode.Single);

        sceneLoading.allowSceneActivation = false;

        float timePast = 0f;

        timePast += Time.timeSinceLevelLoad;

        while (timePast < _loadWaitTime)
        {
            yield return null;
            timePast += Time.deltaTime;
        }

        sceneLoading.allowSceneActivation = true;

        yield return new WaitForSeconds(_vuforiaActivationTime);

        _loadingCircle.StopLoading();
        gameObject.SetActive(false);
    }
}
