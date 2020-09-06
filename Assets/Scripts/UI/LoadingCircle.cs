using System.Collections;
using UnityEngine;

public class LoadingCircle : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 100f;
    [SerializeField] private float _scaleSpeed = 0.2f;

    private float _curentScale = 1f;
    private RectTransform rectComponent;
    private Coroutine _loadingCircleProcess;

    private void Start()
    {
        rectComponent = GetComponent<RectTransform>();
    }

    public void StartLoading()
    {
        StopLoading();

        _loadingCircleProcess = StartCoroutine(LoadingCircleProcess());
    }

    public void StopLoading()
    {
        if (_loadingCircleProcess != null)
            StopCoroutine(_loadingCircleProcess);
    }

    private IEnumerator LoadingCircleProcess()
    {
        while(true)
        {
            yield return new WaitForEndOfFrame();

            Rotate();

            Scale();
        }       
    }

    private void Rotate()
    {
        rectComponent.Rotate(0f, 0f, _rotateSpeed * Time.deltaTime);
    }

    private void Scale()
    {
        _curentScale = Mathf.PingPong(Time.time * _scaleSpeed, 0.7f) + 0.8f;
        rectComponent.localScale = new Vector3(_curentScale, _curentScale, _curentScale);
    }
}