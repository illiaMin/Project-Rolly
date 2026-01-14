using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableStringTurretDictionary
{
    [Serializable]
    private struct Entry
    {
        public string Key;
        public SO_PlayerTurret Value;
    }

    [SerializeField]
    private List<Entry> _entries = new List<Entry>();

    private Dictionary<string, SO_PlayerTurret> _dictionary;

    public bool TryGet(string key, out SO_PlayerTurret value)
    {
        EnsureBuilt();
        return _dictionary.TryGetValue(key, out value);
    }

    public SO_PlayerTurret Get(string key)
    {
        EnsureBuilt();

        if (!_dictionary.TryGetValue(key, out SO_PlayerTurret value))
        {
            throw new KeyNotFoundException($"Key '{key}' not found.");
        }

        return value;
    }

    public bool ContainsKey(string key)
    {
        EnsureBuilt();
        return _dictionary.ContainsKey(key);
    }

    public void Rebuild()
    {
        _dictionary = new Dictionary<string, SO_PlayerTurret>();

        for (int i = 0; i < _entries.Count; i++)
        {
            Entry entry = _entries[i];

            if (string.IsNullOrEmpty(entry.Key))
            {
                continue;
            }

            if (_dictionary.ContainsKey(entry.Key))
            {
                Debug.LogWarning($"Duplicate key '{entry.Key}'");
                continue;
            }

            _dictionary.Add(entry.Key, entry.Value);
        }
    }

    private void EnsureBuilt()
    {
        if (_dictionary == null)
        {
            Rebuild();
        }
    }
}