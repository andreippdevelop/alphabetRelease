using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentWriteText : MonoBehaviour, IContent
{
    [SerializeField] private GameObject _originalPencil;
    [SerializeField] private GameObject _writeLinePrefab;
    [SerializeField] private GameObject _writeObject;

    [SerializeField] private List<Vector2> _setActiveWriteLinesTimers;

    private Coroutine _writeLineTimers;
    private List<GameObject> _drawLines = new List<GameObject>();

    public void ActivateContent()
    {
        SetActiveOriginalObject(false);

        foreach (Vector2 bufTimer in _setActiveWriteLinesTimers)
            StartCoroutine(WriteLineTimer(bufTimer.x, bufTimer.y));
    }

    public void DeactivateContent()
    {
        SetActiveOriginalObject(true);

        if (_writeObject != null)
        {
            StopAllCoroutines();
            RemoveAllDrawLines();
        }
    }

    private IEnumerator WriteLineTimer(float startTime, float endTime)
    {
        GameObject drawLine = null;

        yield return new WaitForSeconds(startTime);
        drawLine = Instantiate(_writeLinePrefab, _writeObject.transform);
        _drawLines.Add(drawLine);

        yield return new WaitForSeconds(endTime-startTime);
        drawLine.transform.parent = transform;
    }

    private void RemoveAllDrawLines()
    {
        if (!_drawLines.IsNullOrEmpty())
        {
            foreach (GameObject buf in _drawLines)
            {
                Destroy(buf);
            }

            _drawLines.Clear();
        }
    }

    private void SetActiveOriginalObject(bool value)
    {
        _originalPencil.SetActive(value);
        _writeObject.SetActive(!value);
    }
}
