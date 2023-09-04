using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ObjectFollower _playerCamera;

    public IInputHandler InputHandler { get; private set; }
    public SessionStats SessionStats { get; private set; }
    public Car ControlledCar { get; private set; }
    public ObjectFollower Camera => _playerCamera;

    public void SetInputHandler(IInputHandler inputHandler)
    {
        InputHandler = inputHandler;
    }

    public void SetCar(Car car)
    {
        ControlledCar = car;
        _playerCamera.Follow(car.transform);
    }

    private void Awake()
    {
        SessionStats = new SessionStats();
    }

    private void Update()
    {
        UpdatePositionData();
    }


    private void FixedUpdate()
    {
        UpdateCar();
    }

    private void UpdatePositionData()
    {
        if (ControlledCar == null)
            return;

        SessionStats.SetDrivedDistance(ControlledCar.transform.position.x);
    }

    private void UpdateCar()
    {
        if(InputHandler == null)
        {
            Debug.LogError($"There is no InputHandler assigned on player!");
            return;
        }

        if (ControlledCar == null)
            return;

        ControlledCar.Accelerate(InputHandler.GasInput);
        ControlledCar.Brake(InputHandler.BrakeInput);
    }
}