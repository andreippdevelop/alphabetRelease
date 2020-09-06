using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PrivacyPolicyTranslator : MonoBehaviour
{
    [System.Serializable]
    public class TextLanguagePolicy
    {
        public Language.LanguageType type;
        public GameObject policyGameObject;
    }

    [SerializeField] private TextLanguagePolicy[] _textLanguagePolicyArray;

    private void Awake()
    {
        Translate();
    }

    private void ResetAll()
    {
        foreach(var privacy in _textLanguagePolicyArray)
        {
            privacy.policyGameObject.SetActive(false);
        }
    }

    private void Translate()
    {
        ResetAll();
        System.Func<TextLanguagePolicy, bool> predicateLanguage;

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

        GameObject activePolicy = _textLanguagePolicyArray.Single(predicateLanguage).policyGameObject;

        activePolicy.SetActive(true);
    }

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            Translate();
        }
    }
}
