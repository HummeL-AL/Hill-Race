using System;
using UnityEngine;

public class RangedResource : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private float _maxValue;

    public float Value => _value;
    public float MaxValue => _maxValue;

    public event Action<float> OnChangeDetected;
    public event Action<float, float> OnValueChanged;

    public void ApplyChange(float addition)
    {
        float newValue = _value + addition;
        float limitedValue = LimitValue(newValue);
        float limitedAddition = newValue - _value;

        SetValue(limitedValue);
        OnChangeDetected?.Invoke(limitedAddition);
    }

    public void SetResource(float newValue)
    {
        float limitedValue = LimitValue(newValue);
        float change = limitedValue - _value;

        ApplyChange(change);
    }

    private void SetValue(float newValue)
    {
        _value = newValue;
        OnValueChanged?.Invoke(newValue, _maxValue);
    }

    private float LimitValue(float value)
    {
        return Mathf.Clamp(value, 0f, _maxValue);
    }
}
