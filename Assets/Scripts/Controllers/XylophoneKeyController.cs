using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XylophoneKeyController : MonoBehaviour
{
    [SerializeField] private AudioClip _xylophoneKeySound;
    [SerializeField] private Color _visualPressColor = Color.white;
    [SerializeField] private MeshRenderer _visual;

    private void Awake()
    {       
        ResetVisual();
    }

    private void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(_xylophoneKeySound, transform.position);

        _visual.material.SetColor("_EmissionColor", _visualPressColor);
    }

    private void OnMouseUp()
    {
        ResetVisual();
    }

    private void ResetVisual()
    {
        _visual.material.color = Color.white;
        _visual.material.SetColor("_EmissionColor", Color.clear);
    }
}
