using UnityEngine;

public class HUD : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private PointerClickHandler _gasButton;
    [SerializeField] private PointerClickHandler _brakeButton;

    [Header("Display")]
    [SerializeField] private AmountDisplay _distanceDisplay;
    [SerializeField] private AmountDisplay _coinCountDisplay;
    [SerializeField] private RangeDisplay _fuelDisplay;

    private Player _player;

    public void SetPlayer(Player player)
    {
        _player = player;
        InitializeDisplays();
    }

    private void InitializeDisplays()
    {
        _player.SessionStats.OnDrivedDistanceChanged += _distanceDisplay.Show;
        _player.SessionStats.OnCollectedCoinsChanged += _coinCountDisplay.Show;
        _player.ControlledCar.Fuel.OnValueChanged += _fuelDisplay.Show;
    }

    private void Awake()
    {
        InitializeInputEvents();
    }

    private void InitializeInputEvents()
    {
        _gasButton.OnPointerPressed += HandleGasPress;
        _gasButton.OnPointerReleased += HandleGasRelease;
        _brakeButton.OnPointerPressed += HandleBrakePress;
        _brakeButton.OnPointerReleased += HandleBrakeRelease;
    }

    private void HandleGasPress()
    {
        _player.InputHandler.GasInput = 1;
    }

    private void HandleGasRelease()
    {
        _player.InputHandler.GasInput = 0;
    }

    private void HandleBrakePress()
    {
        _player.InputHandler.BrakeInput = 1;
    }

    private void HandleBrakeRelease()
    {
        _player.InputHandler.BrakeInput = 0;
    }
}
