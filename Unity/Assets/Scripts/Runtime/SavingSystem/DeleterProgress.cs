using UnityEngine;

public class DeleterProgress : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
}
