using System.Collections.Generic;
using UnityEngine;

public class SaveVariables : MonoBehaviour, ISerializable<VariablesStorageDTO>
{
    [SerializeField] private Dictionary<string, float> _floatVariables = new Dictionary<string, float>();
    [SerializeField] private Dictionary<string, string> _stringVariables = new Dictionary<string, string>();
    [SerializeField] private Dictionary<string, bool> _boolVariables = new Dictionary<string, bool>();
    
    
    public void SetFloat(string key, float value)
    {
        _floatVariables[key] = value;
    }

    public float GetFloat(string key, float value = 0f)
    {
        if (_floatVariables.ContainsKey(key))
        {
            return _floatVariables[key];
        }
        return value;
    }

    public void SetString(string key, string value)
    {
        _stringVariables[key] = value;
    }

    public string GetString(string key, string value = "")
    {
        if (_stringVariables.ContainsKey(key))
        {
            return _stringVariables[key];
        }
        return value;
    }

    public void SetBool(string key, bool value)
    {
        _boolVariables[key] = value;
    }

    public bool GetBool(string key, bool value = false)
    {
        if (_boolVariables.ContainsKey(key))
        {
            return _boolVariables[key];
        }
        return value;
    }

    
    public VariablesStorageDTO Serialized()
    {
        return new VariablesStorageDTO()
        {
            FloatVariables = _floatVariables,
            StringVariables = _stringVariables,
            BoolVariables = _boolVariables,
        };
    }

    public void Deserialize(VariablesStorageDTO dataTransferObject)
    {
        _floatVariables = dataTransferObject.FloatVariables;
        _stringVariables = dataTransferObject.StringVariables;
        _boolVariables = dataTransferObject.BoolVariables;
    }
}