using System.Collections.Generic;
using UnityEngine;

public class FirstSavingInfo : MonoBehaviour
{
    [SerializeField] 
    List<SavingModuleInfo> _startModulesList = new (); // info about modules player has

    public List<SavingModuleInfo> GetStartModulesList()
    {
        return _startModulesList;
    }
}
