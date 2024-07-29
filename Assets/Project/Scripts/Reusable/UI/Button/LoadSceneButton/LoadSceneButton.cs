using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private Button _button;
#if UNITY_EDITOR
    [Dropdown(nameof(Scenes))]
#endif
    [SerializeField] private string _sceneName;

    private SceneLoader _loader;

#if UNITY_EDITOR
    private IReadOnlyCollection<string> Scenes => SceneList.GetScenes();
#endif

    [Inject]
    private void Construct(SceneLoader loader) => _loader = loader;
    public void Awake() => _button.onClick.AddListener(SendLoadRequest);
    private void SendLoadRequest() => _loader.Load(_sceneName);
}