using System.Collections.Generic;
using UnityEngine;

public class HPOwner : MonoBehaviour
{
    [SerializeField] RobotEvents _robotEvents;
    [SerializeField] SavingSystem _savingSystem;
    Shield _shield;
    [SerializeField]List<HP> _hps = new List<HP>();
    Dictionary<TypeOfDamageble, HP> _hpsByType = new Dictionary<TypeOfDamageble, HP>();

    public HP GetHP(TypeOfDamageble typeOfDamageble)
    {
        return _hpsByType[typeOfDamageble];
    }
    public void SetShield(Shield shield)
    {
        _shield = shield;
    }
    public void Add(HP newHp, TypeOfDamageble typeOfDamageble)
    {
        if (_hpsByType.TryGetValue(typeOfDamageble, out HP oldHp))
        {
            _hps.Remove(oldHp);
        }

        _hps.Add(newHp);
        _hpsByType[typeOfDamageble] = newHp;
    }
    public void ReceiveDmg(SO_Damage dmg)
    {
        if (IsProtectedByShield())
        {
            return;
        }

        ApplyDMGToModules(dmg);

        PersistCurrentHpState();
        _robotEvents.InvokeOnDMGRecieved();
    }

    private bool IsProtectedByShield()
    {
        return _shield != null && _shield.GetProtection();
    }

    private void PersistCurrentHpState()
    {
        _savingSystem.SaveMainGunAfterGetDmg(_hpsByType[TypeOfDamageble.Gun].Current);
        _savingSystem.SaveBatteryAfterGetDmg(_hpsByType[TypeOfDamageble.Battery].Current);
        _savingSystem.SaveAuxiliaryAfterGetDmg(_hpsByType[TypeOfDamageble.Auxiliary].Current);
        _savingSystem.SaveVisionAfterGetDmg(_hpsByType[TypeOfDamageble.Vision].Current);
        _savingSystem.SaveWheelsDmg(
            _hpsByType[TypeOfDamageble.WheelsLeft].Current,
            _hpsByType[TypeOfDamageble.WheelsRight].Current);
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
        
        _hpsByType[TypeOfDamageble.Vision].TakeDmg(dmg);
        
        List<HP> modules = new List<HP>(_hps);
        modules.Remove(_hpsByType[TypeOfDamageble.Vision]);
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
        
        _hpsByType[TypeOfDamageble.Auxiliary].TakeDmg(dmg);
        
        List<HP> modules = new List<HP>(_hps);
        modules.Remove(_hpsByType[TypeOfDamageble.Auxiliary]);
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
            _hpsByType[TypeOfDamageble.WheelsLeft].TakeDmg(dmg);
            _hpsByType[TypeOfDamageble.WheelsRight].TakeDmg(dmg/2);
        }
        else if (r == 1)
        {
            _hpsByType[TypeOfDamageble.WheelsRight].TakeDmg(dmg);
            _hpsByType[TypeOfDamageble.WheelsLeft].TakeDmg(dmg/2);
        }
        
        List<HP> modules = new List<HP>(_hps);
        modules.Remove(_hpsByType[TypeOfDamageble.WheelsLeft]);
        modules.Remove(_hpsByType[TypeOfDamageble.WheelsRight]);
 
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
        
        _hpsByType[TypeOfDamageble.Gun].TakeDmg(dmg);
        
        List<HP> modules = new List<HP>(_hps);
        modules.Remove(_hpsByType[TypeOfDamageble.Gun]);
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
