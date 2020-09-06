using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(Text))]
public class TextTranslator : MonoBehaviour
{
    [System.Serializable]
    public class TextLanguage
    {
        public Language.LanguageType type;
        public string text;
    }

    [SerializeField] private TextLanguage[] _textLanguageArray;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Start()
    {
        Translate();
    }

    private void Translate()
    {
        System.Func<TextLanguage, bool> predicateLanguage;

        if (Application.systemLanguage == SystemLanguage.Ukrainian)
        {
            predicateLanguage = x => x.type == Language.LanguageType.Ukraine;
        }
        else if (Application.systemLanguage == SystemLanguage.Russian)
        {
            predicateLanguage = x => x.type == Language.LanguageType.Russian;
        }
        else
        {
            predicateLanguage = x => x.type == Language.LanguageType.English;
        }

        string text = _textLanguageArray.Single(predicateLanguage).text;

        if (!string.IsNullOrEmpty(text))
        {
            _text.text = text;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if(!pause)
        {
            Translate();
        }
    }
}
