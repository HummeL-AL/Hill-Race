using TMPro;
using UnityEngine;

public class AmountDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _amountDisplay;
    [SerializeField] private int _precision;
    [SerializeField] private string _prefix;
    [SerializeField] private string _suffix;

    public void Show(int value)
    {
        _amountDisplay.text = $"{_prefix}{value}{_suffix}";
    }

    public void Show(float value)
    {
        float roundedValue = (float)System.Math.Round(value, _precision);
        _amountDisplay.text = $"{_prefix}{roundedValue}{_suffix}";
    }
}
