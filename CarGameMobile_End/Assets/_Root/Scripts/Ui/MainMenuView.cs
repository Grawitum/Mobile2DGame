using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonIAP;
        [SerializeField] private Button _buttonAds;


        public void Init(UnityAction startGame,UnityAction activeSettingsMenu, UnityAction buy, UnityAction rewarded)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(activeSettingsMenu);
            _buttonAds.onClick.AddListener(rewarded);
            _buttonIAP.onClick.AddListener(buy);
        }


        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonStart.onClick.RemoveAllListeners();
            _buttonAds.onClick.RemoveAllListeners();
            _buttonIAP.onClick.RemoveAllListeners();
        }
    }
}
