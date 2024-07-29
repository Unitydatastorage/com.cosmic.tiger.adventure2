using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SelectLevelButton : MonoBehaviour
{
    [SerializeField] private int LevelID;
    [SerializeField] private Button _button;

    [Inject] private SelectedLevel _selectedLevel;

    public void Awake() => _button.onClick.AddListener(SendLoadRequest);
    private void SendLoadRequest() => _selectedLevel.ID = LevelID;
}