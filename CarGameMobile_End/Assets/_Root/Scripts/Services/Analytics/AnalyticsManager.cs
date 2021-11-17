using UnityEngine;
using Services.Analytics.UnityAnalytics;

namespace Services.Analytics
{
    internal class AnalyticsManager : MonoBehaviour
    {
        private IAnalyticsService[] _services;


        private void Awake()
        {
            InitializeServices();
        }

        private void InitializeServices()
        {
            _services = new IAnalyticsService[]
            {
                new UnityAnalyticsService()
            };
        }


        public void SendMainMenuOpened() =>
            SendEvent("MainMenuOpened");

        public void SendGameStarted() =>
            SendEvent("GameStarted");

        public void SendAnalyticsTransaction(string productID, decimal amount, string currency) =>
            SendTransactionEvent(productID, amount, currency);

        private void SendEvent(string eventName)
        {
            Debug.Log(eventName);
            for (int i = 0; i < _services.Length; i++)
                _services[i].SendEvent(eventName);
        }

        private void SendTransactionEvent(string productID, decimal amount, string currency)
        {
            Debug.Log(productID  + currency);
            for (int i = 0; i < _services.Length; i++)
                _services[i].SendTransactionEvent(productID, amount, currency);
        }
    }
}
