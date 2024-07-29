using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoadingBarView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        _sceneLoader.ProgressChanged += UpdateView;
    }

    private void UpdateView(float progress) => _slider.value = progress;

    private void OnDestroy() => _sceneLoader.ProgressChanged -= UpdateView;
}