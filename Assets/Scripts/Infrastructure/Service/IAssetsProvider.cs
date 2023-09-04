using UnityEngine;

public interface IAssetsProvider : IService
{
    public TAsset LoadAsset<TAsset>(string assetPath) where TAsset : Object;
    public TAsset[] LoadAssets<TAsset>(string assetPath) where TAsset : Object;
}
