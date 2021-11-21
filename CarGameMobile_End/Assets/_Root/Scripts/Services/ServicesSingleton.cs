using Services.Ads.UnityAds;
using Services.Analytics;
using Services.IAP;
using System.Collections.Generic;
using Tool;
using UnityEngine;

namespace Services
{
    internal class ServicesSingleton : MonoBehaviour
    {
        private UnityAdsService _adsService ;
        private AnalyticsManager _analyticsManager;
        private IAPService _iapService;

        private readonly ResourcePath _viewAdsPath = new ResourcePath("Prefabs/Services/Ads");
        private readonly ResourcePath _viewAnalyticsPath = new ResourcePath("Prefabs/Services/Analytics");
        private readonly ResourcePath _viewIAPPath = new ResourcePath("Prefabs/Services/IAP");

        private List<GameObject> _gameObjects;
        private bool _isDisposed;

        public UnityAdsService GetUnityAdsService()
        {
            if(_adsService == null)
            {
                _adsService = CreateServices(_viewAdsPath).GetComponent<UnityAdsService>();
            }
            return _adsService;
        }

        public AnalyticsManager GetAnalyticsManager()
        {
            if (_analyticsManager == null)
            {
                _analyticsManager = CreateServices(_viewAnalyticsPath).GetComponent<AnalyticsManager>();
            }
            return _analyticsManager;
        }

        public IAPService GetIAPService()
        {
            if (_iapService == null)
            {
                _iapService = CreateServices(_viewIAPPath).GetComponent<IAPService>();
                //_iapService.analyticsManager = GetAnalyticsManager();
            }
            return _iapService;
        }

        private GameObject CreateServices(ResourcePath path)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(path);
            GameObject objectView = Object.Instantiate(prefab);
            objectView.transform.parent = this.gameObject.transform;
            AddGameObject(objectView);

            return objectView;
        }

        private void OnDestroy()
        {
            if (_isDisposed)
                return;

            _isDisposed = true;

            DisposeGameObjects();

        }

        private void DisposeGameObjects()
        {
            if (_gameObjects == null)
                return;

            foreach (GameObject gameObject in _gameObjects)
                Object.Destroy(gameObject);

            _gameObjects.Clear();
        }

        protected void AddGameObject(GameObject gameObject)
        {
            _gameObjects ??= new List<GameObject>();
            _gameObjects.Add(gameObject);
        }

    }
}
