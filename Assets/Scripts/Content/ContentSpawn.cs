using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentSpawn : MonoBehaviour, IContent
{
    [SerializeField] private GameObject _contentPrefab;
    private GameObject _contentObject;

    public void ActivateContent()
    {
        _contentObject = Instantiate(_contentPrefab, transform);
    }

    public void DeactivateContent()
    {
        if (_contentObject != null)
            Destroy(_contentObject);
    }

    
}
