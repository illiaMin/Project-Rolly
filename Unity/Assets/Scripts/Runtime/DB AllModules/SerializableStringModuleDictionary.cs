using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableStringModuleDictionary
{
    [Serializable]
    private struct Entry
    {
        public ModuleName Key;
        public ScriptableObject Value;
    }

    [SerializeField]
    private List<Entry> _entries = new List<Entry>();

    private Dictionary<ModuleName, ScriptableObject> _dictionary;

    public bool TryGet(ModuleName key, out ScriptableObject value)
    {
        EnsureBuilt();
        return _dictionary.TryGetValue(key, out value);
    }

    public ScriptableObject Get(ModuleName key)
    {
        EnsureBuilt();

        if (!_dictionary.TryGetValue(key, out ScriptableObject value))
        {
            throw new KeyNotFoundException($"Key '{key}' not found.");
        }
        return value;
    }

    public bool ContainsKey(ModuleName key)
    {
        EnsureBuilt();
        return _dictionary.ContainsKey(key);
    }

    public void Rebuild()
    {
        _dictionary = new Dictionary<ModuleName, ScriptableObject>();

        for (int i = 0; i < _entries.Count; i++)
        {
            Entry entry = _entries[i];

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