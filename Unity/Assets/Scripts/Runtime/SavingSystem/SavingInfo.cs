using System.Collections.Generic;
using UnityEngine;

public class SavingInfo
{
    List<SavingModuleInfo> _modulesList = new ();

    public void SetModulesList(List<SavingModuleInfo> modulesList)
    {
        _modulesList = modulesList;
    }
    
    public List<SavingModuleInfo> GetModulesList()
    {
        return _modulesList;
    }
}
