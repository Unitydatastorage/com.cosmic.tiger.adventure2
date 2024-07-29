using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public event Action<float> ProgressChanged;

    public async void Load(string name)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(name);

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            var progress = asyncOperation.progress;

            ProgressChanged?.Invoke(asyncOperation.progress);

            await Task.Yield();

            if (progress >= 0.9f) asyncOperation.allowSceneActivation = true;
        }
    }
}