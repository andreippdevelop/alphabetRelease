using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class ObjectTargetLinker : MonoBehaviour
{

#if UNITY_EDITOR

    private ObjectTargetController _objectTarget;
    private string _pathToDescriptions = "Assets/Audio/Description";
    private string _pathToSounds = "Assets/Audio/Sounds";
    private string _pathTo3DAlphabet = "Assets/Content/3DFont/Alphabet";

    private string _audioFileExtensionWav = "*.wav";
    private string _audioFileExtensionMp3 = "*.mp3";
    private string _modelFileExtension = "*.fbx";

    public void DefaultInitialization()
    {
        _objectTarget = GetComponent<ObjectTargetController>();
        var languageTypes = System.Enum.GetValues(typeof(Language.LanguageType));

        _objectTarget.descriptions = new TargetObjectDescription[languageTypes.Length];
        int i = 0;

        foreach (var langType in languageTypes)
        {
            _objectTarget.descriptions[i] = new TargetObjectDescription();
            _objectTarget.descriptions[i].type = (Language.LanguageType)langType;
            i++;
        }

        _objectTarget.sounds = new AudioClip[1];

        LinkDataWithDelay(1);
    }

    private async void LinkDataWithDelay(int delayInSeconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));

        LinkData();
    }

    private void LinkData()
    {
        string generallSearchingPattern = this.name.ToLower();
        string alphabetSoundSearchingPattern = this.name.ElementAt(0).ToString().ToLower();
        string alphabetModelSearchingPattern = this.name.ElementAt(0).ToString().ToUpper();

        LinkDiscriptions(_pathToDescriptions, alphabetSoundSearchingPattern, generallSearchingPattern);
        LinkSounds(_pathToSounds, alphabetSoundSearchingPattern, generallSearchingPattern);
        LinkModel(_pathTo3DAlphabet, alphabetModelSearchingPattern);
    }

    private void LinkDiscriptions(string pathToDescriptionWithTargetTypeData, string alphabetSearchingPattern, string generallSearchingPattern)
    {
        if (_objectTarget.descriptions.Length > 0)
        {
            for (int i = 0; i < _objectTarget.descriptions.Length; i++)
            {
                string pathToAudioDescription = pathToDescriptionWithTargetTypeData + "/" +
                    Language.GetLanguageTextValue(_objectTarget.descriptions[i].type);

                string currentSearchingPattern = (i == 0) ? alphabetSearchingPattern : generallSearchingPattern;
                string audioFileName =
                     GetFileNameFromDirrectory(pathToAudioDescription, currentSearchingPattern, _audioFileExtensionWav);

                string fullAudioPath = pathToAudioDescription + "/" + audioFileName;
                Debug.Log(fullAudioPath);
                _objectTarget.descriptions[0].textDesctiption = this.name;

                _objectTarget.descriptions[i].audioDescription = 
                    (AudioClip)AssetDatabase.LoadAssetAtPath(fullAudioPath, typeof(AudioClip));

            }
        }
    }

    private void LinkSounds(string pathToSoundsWithTargetTypeData, string alphabetSearchingPattern, string generallSearchingPattern)
    {
        if (_objectTarget.sounds.Length > 0)
        {
            string audioFileName =
                   GetFileNameFromDirrectory(pathToSoundsWithTargetTypeData, generallSearchingPattern, _audioFileExtensionMp3);

            string fullAudioPath = pathToSoundsWithTargetTypeData + "/" + audioFileName;

            _objectTarget.sounds[0] = (AudioClip)AssetDatabase.LoadAssetAtPath(fullAudioPath, typeof(AudioClip));
        }
    }

    private void LinkModel(string pathToModelsWithTargetTypeData, string alphabetSearchingPattern)
    {
        Debug.Log(alphabetSearchingPattern);

        string modelFileName =
                   GetFileNameFromDirrectory(
                        pathToModelsWithTargetTypeData,
                        alphabetSearchingPattern, 
                        _modelFileExtension);

        Debug.Log(modelFileName);

        string fullModelPath = pathToModelsWithTargetTypeData + "/" + modelFileName;
        Debug.Log(fullModelPath);

        if (_objectTarget.alphabetSymbol == null)
        {
            _objectTarget.alphabetSymbol = (GameObject)AssetDatabase.LoadAssetAtPath(fullModelPath, typeof(GameObject));

            SetUpSymbolInScene();
        }
    }

    private void SetUpSymbolInScene()
    {
        GameObject symbol = (GameObject)PrefabUtility.InstantiatePrefab(_objectTarget.alphabetSymbol);

        symbol.transform.SetParent(transform);

        symbol.transform.localPosition = new Vector3(0f, 1.5f, 0f);
        symbol.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
        symbol.transform.localScale /= 3f;

        symbol.GetComponent<MeshRenderer>().material.color = _objectTarget.symbolColor;
        symbol.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", _objectTarget.symbolColor);

        symbol.AddComponent<ContentAlphabetScale>();
    }

    private string GetFileNameFromDirrectory(string directoryPath, string searchingPattern, string fileExtension)
    {
        string fileName = string.Empty;

        DirectoryInfo dir = new DirectoryInfo(directoryPath);
        FileInfo[] info = dir.GetFiles(fileExtension);

        foreach (FileInfo f in info)
        {
            string fileNameWithoutExtension = f.Name.Substring(0, f.Name.LastIndexOf(".") + 1);

            if (fileNameWithoutExtension.Contains(searchingPattern))
            {
                fileName = f.Name;
                break;
            }
        }

        return fileName;
    }
#endif
}
