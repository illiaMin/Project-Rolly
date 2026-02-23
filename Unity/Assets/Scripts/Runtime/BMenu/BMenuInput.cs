using UnityEngine;
using UnityEngine.UI;

public class BMenuInput : MonoBehaviour
{
    private Text _textBMenu;
    [SerializeField] string _textB_menu = "B-Menu";
    private Text _textMainGun;
    [SerializeField] private string _stringMainGun = "Main Gun: ";
    private Text _textSecondGun;
    [SerializeField] private string _stringSecondGun = "Secondary Gun: ";
    private Text _textActiveWheels;
    [SerializeField] private string _stringActiveWheels = "Active Wheels: ";
    private Text _textAuxiliry;
    [SerializeField] private string _stringAuxiliary = "Auxiliary: ";
    public void Init(Text textBMenu, Text textMainGun, Text textSecondGun, Text textActiveWheels, Text textAuxiliary)
    {
        _textBMenu = textBMenu;
        _textMainGun = textMainGun;
        _textSecondGun = textSecondGun;
        _textActiveWheels = textActiveWheels;
        _textAuxiliry = textAuxiliary;
    }
    public void Toggle(bool active)
    {
        GameObject target = _textBMenu.gameObject;
        target.SetActive(active);
    }
    public void Show(string toShow)
    {
        _textBMenu.text = "";
        _textBMenu.text += _textB_menu + "\n  " + toShow;
    }

    public void ChangeMainGun(string name)
    {
        _textMainGun.text = _stringMainGun + name;
    }

    public void ChangeSecondGun(string name)
    {
        _textSecondGun.text = _stringSecondGun + name;
    }
    public void ChangeActiveWheels(string name)
    {
        _textActiveWheels.text = _stringActiveWheels + name;
    }
    public void ChangeActiveAuxiliary(string name)
    {
        _textAuxiliry.text = _stringAuxiliary + name;
    }
}


