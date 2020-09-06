using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BlinkText : MonoBehaviour
{
    [SerializeField]
    private float _blinkDelay = 0.02f;

    [SerializeField]
    private float _blinkStep = 0.02f;

    private Text _text;

    void Awake()
    {
        _text = GetComponent<Text>();
    }

    void OnEnable()
    {
        StartCoroutine("StartBlink");
    }

    void OnDisable()
    {
        StopBlink();
    }

    private IEnumerator StartBlink()
    {
        while (true)
        {
            for (float tempAlpha = _text.color.a; tempAlpha > _blinkStep; tempAlpha -= _blinkStep)
            {
                yield return new WaitForSeconds(_blinkDelay);

                _text.color = new Color(_text.color.r,
                    _text.color.g,
                    _text.color.b,
                    tempAlpha);
            }

            for (float tempAlpha = _text.color.a; tempAlpha < 1f; tempAlpha += _blinkStep)
            {
                yield return new WaitForSeconds(_blinkDelay);

                _text.color = new Color(_text.color.r,
                    _text.color.g,
                    _text.color.b,
                    tempAlpha);
            }
        }
    }

    private void StopBlink()
    {
        StopCoroutine("StartBlink");
    }
}
