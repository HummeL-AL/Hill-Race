using System;

public interface ISceneLoader : IService
{
    public void Load(string id, Action onLoaded = null);
}
