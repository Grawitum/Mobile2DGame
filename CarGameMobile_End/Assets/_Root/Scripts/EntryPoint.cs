using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    private const float SpeedCar = 15f;
    private const GameState InitialState = GameState.Start;


    [SerializeField] private Transform _placeForUi;
    //enum CarModel
    //{
    //    Car,
    //    Boat
    //}
    //[SerializeField] private CarModel _carModel = CarModel.Car;
    //[SerializeField] private EnumCar.CarModel _carModel = EnumCar.CarModel.Car;

    [SerializeField] private SelectCar _carModel = SelectCar.Car;
    [SerializeField] private SelectInputController _inputController = SelectInputController.Acceleration;

    private MainController _mainController;


    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, InitialState);
        _mainController = new MainController(_placeForUi, profilePlayer,_carModel,_inputController);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
