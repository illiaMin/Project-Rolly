using UnityEngine;

public class HPSetter
{
    private HPOwner _hpOwner;

    public HPSetter(HPOwner hpOwner)
    {
        _hpOwner = hpOwner;
    }
    public void SetHpToOwner(ref HP hp, TypeOfDamageble typeOfDamageble)
    {
        _hpOwner.Add(hp, typeOfDamageble);
    }

    public void OnTurretChanged(Turret turret)
    {
        SetHpToOwner(ref turret.GetHP(), TypeOfDamageble.Gun);
    }

    public void OnWheelsChanged(Wheels wheels)
    {
        SetHpToOwner(ref wheels.GetLeftHP(), TypeOfDamageble.WheelsLeft);
        SetHpToOwner(ref wheels.GetRightHP(), TypeOfDamageble.WheelsRight);
    }

    public void OnBatteryChanged(Battery battery)
    {
        SetHpToOwner(ref battery.GetHP(), TypeOfDamageble.Battery);
    }

    public void OnAuxiliaryChanged(AuxiliaryModule auxiliaryModule)
    {
        SetHpToOwner(
            ref auxiliaryModule.GetHP(), TypeOfDamageble.Auxiliary);
    }
}
