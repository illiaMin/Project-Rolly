using System.Collections.Generic;
using UnityEngine;

public class HPOwner : MonoBehaviour
{
    [SerializeField] RobotEvents _robotEvents;
    [SerializeField] SavingSystem _savingSystem;
    bool _hasShield = false;
    Shield _shield;
    [SerializeField]List<HP> _hps = new List<HP>();
    Dictionary<TypeOfDamageble, int> _indexesInHP = new Dictionary<TypeOfDamageble, int>();

    public HP GetHP(TypeOfDamageble typeOfDamageble)
    {
        return _hps[_indexesInHP[typeOfDamageble]];
    }
    public void Init(Shield shield)
    {
        _shield = shield;
    }
    public void Add(HP newHp, TypeOfDamageble typeOfDamageble)
    {
        if (_indexesInHP.ContainsKey(typeOfDamageble))
        {
            HP oldHp = _hps[_indexesInHP[typeOfDamageble]];
            _hps.Remove(oldHp);
            _hps.Add(newHp);
            _indexesInHP[typeOfDamageble] = _hps.IndexOf(newHp);
        }
        else
        {
            _hps.Add(newHp);
            _indexesInHP.Add(typeOfDamageble, _hps.IndexOf(newHp));
        }
    }
    public void ReceiveDmg(SO_Damage dmg)
    {
        if (_hasShield)
        {
            if (_shield.GetProtection())
            {
                return;
            }
            ApplyDMGToModules(dmg);
        }
        else
        {
            ApplyDMGToModules(dmg);
        }

        _savingSystem.SaveMainGunAfterGetDmg(_hps[_indexesInHP[TypeOfDamageble.Gun]].Current);
        _savingSystem.SaveBatteryAfterGetDmg(_hps[_indexesInHP[TypeOfDamageble.Battery]].Current);
        _savingSystem.SaveAuxiliaryAfterGetDmg(_hps[_indexesInHP[TypeOfDamageble.Auxiliary]].Current);
        _savingSystem.SaveVisionAfterGetDmg(_hps[_indexesInHP[TypeOfDamageble.Vision]].Current);
        _savingSystem.SaveWheelsDmg(
            _hps[_indexesInHP[TypeOfDamageble.WheelsLeft]].Current,
            _hps[_indexesInHP[TypeOfDamageble.WheelsRight]].Current);
        
        _robotEvents.InvokeOnDMGRecieved();
    }

    #region ApplyDMGToModules

     private void ApplyDMGToModules(SO_Damage dmg)
    {
        ApplyBasicDMG(dmg.BasicDmg);
        ApplyPhysicsDMG(dmg.PhysicDmg);
        ApplyFireDMG(dmg.FireDmg);
        ApplyElectroDMG(dmg.ElectricDmg);
        ApplyNanoDmg(dmg.NanoDmg);
    }
    private void ApplyNanoDmg(int dmg)
    {
        if (dmg == 0) return;
        
        _hps[_indexesInHP[TypeOfDamageble.Vision]].TakeDmg(dmg);
        
        List<HP> modules = new List<HP>(_hps);
        modules.Remove(_hps[_indexesInHP[TypeOfDamageble.Vision]]);
        HP module1 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module1);
        HP module2 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module2);
        HP module3 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module3);
        module1.TakeDmg(dmg/2);
        int k = Random.Range(0, dmg / 2);
        module2.TakeDmg(dmg - k);
        module3.TakeDmg(k);
    }
    private void ApplyElectroDMG(int dmg)
    {
        if (dmg == 0) return;
        
        _hps[_indexesInHP[TypeOfDamageble.Auxiliary]].TakeDmg(dmg);
        
        List<HP> modules = new List<HP>(_hps);
        modules.Remove(_hps[_indexesInHP[TypeOfDamageble.Auxiliary]]);
        HP module1 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module1);
        HP module2 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module2);
        HP module3 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module3);
        module1.TakeDmg(dmg/2);
        int k = Random.Range(0, dmg / 2);
        module2.TakeDmg(dmg - k);
        module3.TakeDmg(k);
    }
    private void ApplyFireDMG(int dmg)
    {
        if (dmg == 0) return;
        
        int r = Random.Range(0, 2);
        if (r == 0)
        {
            _hps[_indexesInHP[TypeOfDamageble.WheelsLeft]].TakeDmg(dmg);
            _hps[_indexesInHP[TypeOfDamageble.WheelsRight]].TakeDmg(dmg/2);
        }
        else if (r == 1)
        {
            _hps[_indexesInHP[TypeOfDamageble.WheelsRight]].TakeDmg(dmg);
            _hps[_indexesInHP[TypeOfDamageble.WheelsLeft]].TakeDmg(dmg/2);
        }
        
        List<HP> modules = new List<HP>(_hps);
        modules.Remove(_hps[_indexesInHP[TypeOfDamageble.WheelsLeft]]);
        modules.Remove(_hps[_indexesInHP[TypeOfDamageble.WheelsRight]]);
 
        HP module2 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module2);
        HP module3 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module3);
        int k = Random.Range(0, dmg / 2);
        module2.TakeDmg(dmg - k);
        module3.TakeDmg(k);
    }
    private void ApplyPhysicsDMG(int dmg)
    {
        if (dmg == 0) return;
        
        _hps[_indexesInHP[TypeOfDamageble.Gun]].TakeDmg(dmg);
        
        List<HP> modules = new List<HP>(_hps);
        modules.Remove(_hps[_indexesInHP[TypeOfDamageble.Gun]]);
        HP module1 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module1);
        HP module2 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module2);
        HP module3 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module3);
        module1.TakeDmg(dmg/2);
        int k = Random.Range(0, dmg / 2);
        module2.TakeDmg(dmg - k);
        module3.TakeDmg(k);
    }
    private void ApplyBasicDMG(int dmg)
    {
        if (dmg == 0) return;
        List<HP> modules = new List<HP>(_hps);
        HP module0 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module0);
        HP module1 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module1);
        HP module2 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module2);
        HP module3 = modules[Random.Range(0, modules.Count)];
        modules.Remove(module3);
        module0.TakeDmg(dmg);
        module1.TakeDmg(dmg/2);
        int k = Random.Range(0, dmg / 2);
        module2.TakeDmg(dmg - k);
        module3.TakeDmg(k);
    }

    #endregion
}

public enum TypeOfDamageble
{
    Vision,
    Auxiliary,
    WheelsLeft,
    WheelsRight,
    Gun,
    Battery
}