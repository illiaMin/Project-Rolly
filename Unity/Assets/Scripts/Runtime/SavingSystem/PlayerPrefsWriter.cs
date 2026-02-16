using UnityEngine;

public class PlayerPrefsWriter
{
    public void Write(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    public void Write(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
}
