using UnityEngine;

public class PlayerPrefsReader
{
    public int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    public string GetString(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
}
