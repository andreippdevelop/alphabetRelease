using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OkEnabler : MonoBehaviour
{
    [SerializeField]private Button _okButton;
    [SerializeField] private Text _text;

    [SerializeField] private Color _disableColor;
    [SerializeField] private Color _enableColor;

    private ScrollRect _scrollView;


	private void Awake()
	{
        _scrollView = GetComponent<ScrollRect>();
	}


    public void OnValueChange(Vector2 value)
    {
        if (_okButton == null) return;

        if(value.y>0.01f)
        {
            _okButton.interactable = false;
            _text.color = _disableColor;
        }
        else
        {
            _okButton.interactable = true;
            _text.color = _enableColor;
        }
    }
}
