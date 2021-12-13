using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AssetBundles : MonoBehaviour
{
    [SerializeField] private Button _button;

    private static string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1fCBk2fcQbnyItaPtj2kMWq7Tg42HT6Nh";

    private AssetBundle _spritesAssetBundle;        
    public void OnClickAction()
    {
        _button.interactable = false;
        StartCoroutine(DownloadAndSetAssetBundle());
    }

    protected IEnumerator DownloadAndSetAssetBundle()
    {
        yield return GetSpritesAssetBundle();

        if (_spritesAssetBundle == null)
        {
            Debug.LogError($"AssetBundle {_spritesAssetBundle} failed to load");
            yield break;
        }

        SetDownloadAssets();
        yield return null;
    }

    private IEnumerator GetSpritesAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        StateRequest(request, ref _spritesAssetBundle);
    }

    private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
    {
        if (request.error == null)
        {
            assetBundle = DownloadHandlerAssetBundle.GetContent(request);
            Debug.Log("Complete");
        }
        else
        {
            Debug.Log(request.error);
        }
    }

    private void SetDownloadAssets()
    {
        _button.image.sprite = _spritesAssetBundle.LoadAsset<Sprite>("PlankSprite");
    }

}
