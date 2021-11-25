using Ui;
using Game;
using Profile;
using UnityEngine;
using Features.Shed;
using Features.Shed.Upgrade;
using Features.Inventory;
using Tool;

internal class MainController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    private MainMenuController _mainMenuController;
    private SettingsMenuController _settingsMenuController;
    private ShedController _shedController;
    private GameController _gameController;


    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _settingsMenuController?.Dispose();
        _shedController?.Dispose();
        _gameController?.Dispose();

        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _settingsMenuController?.Dispose();
                _shedController?.Dispose();
                _gameController?.Dispose();
                break;
            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                _shedController?.Dispose();
                _gameController?.Dispose();
                break;
            case GameState.Shed:  
                var shedRepository = CreateShedRepository();
                var inventoryController = CreateInventoryController(_placeForUi);
                var shedView = CreateShedView(_placeForUi);
                _shedController = new ShedController(shedView, shedRepository, inventoryController, _profilePlayer);
                _mainMenuController?.Dispose();
                _settingsMenuController?.Dispose();
                _gameController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_placeForUi, _profilePlayer);
                _settingsMenuController?.Dispose();
                _mainMenuController?.Dispose();
                _shedController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _settingsMenuController?.Dispose();
                _gameController?.Dispose();
                _shedController?.Dispose();
                break;
        }
    }

    private IUpgradeHandlersRepository CreateShedRepository()
    {
        ResourcePath path = new ResourcePath("Configs/Shed/UpgradeItemConfigDataSource");
        UpgradeItemConfig[] upgradeConfigs = ContentDataSourceLoader.LoadUpgradeItemConfigs(path);
        var repository = new UpgradeHandlersRepository(upgradeConfigs);

        return repository;
    }

    private IInventoryController CreateInventoryController(Transform placeForUi)
    {
        var inventoryController = new InventoryController(placeForUi, _profilePlayer.Inventory);

        return inventoryController;
    }

    private GameObject CreateShedView(Transform placeForUi)
    {
        ResourcePath path = new ResourcePath("Prefabs/Shed/ShedView");
        GameObject prefab = ResourcesLoader.LoadPrefab(path);
        GameObject objectView = UnityEngine.Object.Instantiate(prefab, placeForUi, false);

        return objectView;
    }
}
