using UnityEngine;

public class AssetsProvider : IAssetsProvider
{
    public TAsset LoadAsset<TAsset>(string assetPath) where TAsset : Object
    {
        return Resources.Load<TAsset>(assetPath);
    }

    public TAsset[] LoadAssets<TAsset>(string assetPath) where TAsset : Object
    {
        return Resources.LoadAll<TAsset>(assetPath);
    }
}
