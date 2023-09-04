using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isHeld;
    public bool IsHeld => _isHeld;

    public event Action OnPointerPressed;
    public event Action OnPointerReleased;
    public event Action OnPointerHeld;

    public void OnPointerDown(PointerEventData eventData)
    {
        Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Release();
    }

    private void Update()
    {
        if(_isHeld)
        {
            OnPointerHeld?.Invoke();
        }
    }

    private void Press()
    {
        _isHeld = true;

        OnPointerPressed?.Invoke();
    }

    private void Release()
    {
        _isHeld = false;

        OnPointerReleased?.Invoke();
    }
}
