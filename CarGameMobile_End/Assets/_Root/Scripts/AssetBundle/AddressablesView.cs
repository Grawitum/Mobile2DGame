using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressablesView : MonoBehaviour
{
    [SerializeField] private AssetReference loadableSprite;

    [SerializeField]
    private Button _addBackgroundButton;

    [SerializeField]
    private Button _removeBackgroundButton;

    private List<AsyncOperationHandle<Sprite>> _addressableSprites = new List<AsyncOperationHandle<Sprite>>();

    private AsyncOperationHandle<Sprite> _handle;

    [SerializeField] private Image _backGround;
    void Start()
    {
        _addBackgroundButton.onClick.AddListener(AddBackground);
        _removeBackgroundButton.onClick.AddListener(RemoveBackground);
    }

    private void OnDestroy()
    {
        _addBackgroundButton.onClick.RemoveAllListeners();
        _removeBackgroundButton.onClick.RemoveAllListeners();

        foreach (var addressablePrefab in _addressableSprites)
            Addressables.ReleaseInstance(addressablePrefab);

        _addressableSprites.Clear();
    }

    public async void AddBackground()
    {

        _handle = loadableSprite.LoadAssetAsync<Sprite>();
        await _handle.Task;
        if (_handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = _handle.Result;
            _backGround.sprite = sprite;
            _addressableSprites.Add(_handle);
        }
    }

    public void RemoveBackground()
    {
        _backGround.sprite = null;
        Addressables.ReleaseInstance(_handle);
    }
}
