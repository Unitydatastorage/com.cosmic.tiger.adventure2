using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuLoad : MonoBehaviour
{
#if UNITY_EDITOR
    [Dropdown(nameof(Scenes))]
#endif
    [SerializeField] private string _menuSceneName;

    private SceneLoader _loader;

#if UNITY_EDITOR
    private IReadOnlyCollection<string> Scenes => SceneList.GetScenes();
#endif
    [Inject]
    private void Construct(SceneLoader loader) => _loader = loader;
    public void Start() => _loader.Load(_menuSceneName);
}