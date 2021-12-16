using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocalizationWindow : MonoBehaviour
{
    [SerializeField]
    private Button _russianButton;

    [SerializeField]
    private Button _englishButton;

    private void Start()
    {
        _russianButton.onClick.AddListener(() => ChangeLanguage(1));
        _englishButton.onClick.AddListener(() => ChangeLanguage(0));
    }

    private void OnDestroy()
    {
        _russianButton.onClick.RemoveAllListeners();
        _englishButton.onClick.RemoveAllListeners();
    }

    private void ChangeLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
