using Profile;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;


        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame,ActiveSettingsMenu, OnIapInitialized, OnAdsInitialized);
            _profilePlayer.ServicesSingleton.GetAnalyticsManager().SendMainMenuOpened();
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame() =>
            _profilePlayer.CurrentState.Value = GameState.Game;

        private void ActiveSettingsMenu() =>
            _profilePlayer.CurrentState.Value = GameState.Settings;

        private void OnAdsInitialized() => 
            _profilePlayer.ServicesSingleton.GetUnityAdsService().RewardedPlayer.Play();

        private void OnIapInitialized() =>
            _profilePlayer.ServicesSingleton.GetIAPService().Buy("2");
    }
}