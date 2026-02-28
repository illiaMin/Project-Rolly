using UnityEngine;
using UnityEngine.UI;

public class HPUIConteineer : MonoBehaviour
{
    [SerializeField] private int _maxRInColor;
    public int GetMaxRInColor() => _maxRInColor;
    [SerializeField] private int _maxGInColor;
    public int GetMaxGInColor() => _maxGInColor;
    [SerializeField] private int _maxBInColor;
    public int GetMaxBInColor() => _maxBInColor;
    
    [SerializeField] private Image _vision;
    public Image GetImgVision() => _vision;
    
    [SerializeField] private Image _gun;
    public Image GetImgGun() => _gun;
    
    [SerializeField] private Image _battery;
    public Image GetImgBattery() => _battery;
    
    [SerializeField] private Image _auxiliary;
    public Image GetImgAuxiliary() => _auxiliary;
    
    [SerializeField] private Image _wheelsLeft;
    public Image GetImgWheelsLeft() => _wheelsLeft;
    
    [SerializeField] private Image _wheelsRight;
    public Image GetImgWheelsRight() => _wheelsRight;
    
    [SerializeField] private Image _bmenu;
    public Image GetImgBmenu() => _bmenu;
}
