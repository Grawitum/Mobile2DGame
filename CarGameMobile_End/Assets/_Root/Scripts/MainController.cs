using Ui;
using Game;
using Profile;
using UnityEngine;

internal class MainController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    private MainMenuController _mainMenuController;
    private SettingsMenuController _settingsMenuController;
    private GameController _gameController;
    private SelectCar _carModel;
    private SelectInputController _inputController;


    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, SelectCar carModel, SelectInputController inputController)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _carModel = carModel;
        _inputController = inputController;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();

        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                _settingsMenuController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_profilePlayer,_carModel,_inputController);
                _mainMenuController?.Dispose();
                break;
            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
        }
    }
}
