using System;

public class SessionStats
{
    private float _drivedDistance;
    private int _collectedCoins;

    public event Action<float> OnDrivedDistanceChanged;
    public event Action<int> OnCollectedCoinsChanged;

    public void SetDrivedDistance(float value)
    {
        _drivedDistance = value;
        OnDrivedDistanceChanged?.Invoke(_drivedDistance);
    }

    public void SetCoins(int value)
    {
        _collectedCoins = value;
        OnCollectedCoinsChanged?.Invoke(_collectedCoins);
    }

    public void AddCoins(int value)
    {
        _collectedCoins += value;
        OnCollectedCoinsChanged?.Invoke(_collectedCoins);
    }
}