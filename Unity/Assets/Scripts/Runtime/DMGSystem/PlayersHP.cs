using UnityEngine;

public class PlayersHP : MonoBehaviour
{
    private PlayerSetup _playerSetup;
    private HPUIConteineer _hpUI;
    private HPOwner _owner;

    public void Init(PlayerSetup playerSetup, HPUIConteineer hpUI, HPOwner owner)
    {
        _playerSetup = playerSetup;
        _hpUI = hpUI;
        _owner = owner;
        ShowHPs();
    }

    #region ShowHPs

    public void ShowHPs()
    {
        ShowHPForGun();
        ShowHPForBattery();
        ShowHPForVision();
        ShowHPForAuxiliary();
        ShowHPForLeftWheels();
        ShowHPForRightWheels();
        if (BMenuModuleInstalled())
        {
            ShowHPForBMenu();
        }
    }

    private bool BMenuModuleInstalled()
    {
        return _playerSetup.GetBMenuInstalled();
    }
    private void ShowHPForBMenu()
    {
        int percent = 100;
        Color color = CalculateColor(percent);
        _hpUI.GetImgBmenu().color = color;
        _hpUI.GetImgBmenu().gameObject.SetActive(true);
    }
    private void ShowHPForRightWheels()
    {
        int percent = _owner.GetHP(TypeOfDamageble.WheelsRight).Percent;
        Color color = CalculateColor(percent);
        _hpUI.GetImgWheelsRight().color = color;
    }
    private void ShowHPForLeftWheels()
    {
        int percent = _owner.GetHP(TypeOfDamageble.WheelsLeft).Percent;
        Color color = CalculateColor(percent);
        _hpUI.GetImgWheelsLeft().color = color;
    }
    private void ShowHPForAuxiliary()
    {
        int percent = _owner.GetHP(TypeOfDamageble.Auxiliary).Percent;
        Color color = CalculateColor(percent);
        _hpUI.GetImgAuxiliary().color = color;
    }

    private void ShowHPForVision()
    {
        int percent = _owner.GetHP(TypeOfDamageble.Vision).Percent;
        Color color = CalculateColor(percent);
        _hpUI.GetImgVision().color = color;
    }
    private void ShowHPForBattery()
    {
        int percent = _owner.GetHP(TypeOfDamageble.Battery).Percent;
        Color color = CalculateColor(percent);
        _hpUI.GetImgBattery().color = color;
    }
    private void ShowHPForGun()
    {
        int percent = _owner.GetHP(TypeOfDamageble.Gun).Percent;
        Color color = CalculateColor(percent);
        _hpUI.GetImgGun().color = color;
    }
    private Color CalculateColor(int percent)
    {
        float t = percent / 100f;

        float r = (float)_hpUI.GetMaxRInColor() * (1f - t);
        float g = (float)_hpUI.GetMaxGInColor() * t;
        float b = (float)_hpUI.GetMaxBInColor();

        r /= 255f;
        g /= 255f;
        b /= 255f;
        
        return new Color(r, g, b);
    }

    #endregion
    
}
