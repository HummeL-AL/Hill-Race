using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
    private ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
    }

    public void Load(string sceneName, Action onLoaded = null)
    {
        _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
    }

    private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
    {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneName);

        while (!sceneLoading.isDone)
            yield return null;

        onLoaded?.Invoke();
    }
}
