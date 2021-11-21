using Profile;
using Services;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    private const float SpeedCar = 15f;
    private const GameState InitialState = GameState.Start;

    [SerializeField] private Transform _placeForUi;

    [SerializeField] private ServicesSingleton _servicesSingleton;

    [SerializeField] private SelectCar _carType = SelectCar.Car;
    [SerializeField] private SelectInputController _inputController = SelectInputController.Acceleration;

    private MainController _mainController;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, InitialState,_servicesSingleton);
        _servicesSingleton.GetAnalyticsManager().SendGameStarted();
        _mainController = new MainController(_placeForUi, profilePlayer, _carType, _inputController);

        _servicesSingleton.GetUnityAdsService().Initialized.AddListener(_servicesSingleton.GetUnityAdsService().InterstitialPlayer.Play);
        _servicesSingleton.GetIAPService().Buy("1");
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
