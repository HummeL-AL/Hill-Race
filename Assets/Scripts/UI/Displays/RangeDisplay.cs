using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RangeDisplay : MonoBehaviour
{
    [SerializeField] private Image _fillDisplay;
    [SerializeField] private TMP_Text _rangeDisplay;
    [SerializeField] private string _separator;
    [SerializeField] private bool _showValues;

    public void Show(float currentValue, float maxValue)
    {
        UpdateFill(currentValue / maxValue);
        if(_showValues)
        {
            UpdateText(currentValue, maxValue);
        }
    }

    private void UpdateFill(float percentage)
    {
        _fillDisplay.fillAmount = percentage;
    }

    private void UpdateText(float currentValue, float maxValue)
    {
        _rangeDisplay.text = $"{currentValue}{_separator}{maxValue}";
    }
}
