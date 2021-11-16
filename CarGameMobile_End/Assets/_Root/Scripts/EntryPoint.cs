using Profile;
using Services;
using Services.Ads.UnityAds;
using Services.Analytics;
using Services.IAP;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    private const float SpeedCar = 15f;
    private const GameState InitialState = GameState.Start;


    [SerializeField] private Transform _placeForUi;
    //private UnityAdsService _adsService;
    //private AnalyticsManager _analyticsManager;
    //private IAPService _iapService;

    [SerializeField] private ServicesSingleton _servicesSingleton;

    [SerializeField] private SelectCar _carModel = SelectCar.Car;
    [SerializeField] private SelectInputController _inputController = SelectInputController.Acceleration;

    private MainController _mainController;


    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, InitialState,_servicesSingleton);
        _mainController = new MainController(_placeForUi, profilePlayer, _carModel, _inputController);

        //_adsService = _servicesSingleton.GetUnityAdsService();
        _servicesSingleton.GetUnityAdsService().Initialized.AddListener(_servicesSingleton.GetUnityAdsService().InterstitialPlayer.Play);
        //_analyticsManager = _servicesSingleton.GetAnalyticsManager();
        _servicesSingleton.GetAnalyticsManager().SendMainMenuOpened();
        //_iapService = _servicesSingleton.GetIAPService();
        _servicesSingleton.GetIAPService().Initialized.AddListener(OnIapInitialized);
        //_adsService.Initialized.AddListener(_adsService.InterstitialPlayer.Play);
        //_analyticsManager.SendMainMenuOpened();
    }

    private void OnDestroy()
    {
        _servicesSingleton.GetIAPService().Initialized.RemoveListener(OnIapInitialized);
        //_adsService.Initialized.RemoveListener(OnAdsInitialized);
        _servicesSingleton.GetUnityAdsService().Initialized.RemoveListener(OnAdsInitialized);
        _mainController.Dispose();
    }

    private void OnIapInitialized() => _servicesSingleton.GetIAPService().Buy("product_1");
    //private void OnAdsInitialized() => _adsService.InterstitialPlayer.Play();

    private void OnAdsInitialized() => _servicesSingleton.GetUnityAdsService().InterstitialPlayer.Play();

}
