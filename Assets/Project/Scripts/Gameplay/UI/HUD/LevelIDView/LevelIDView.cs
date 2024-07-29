using TMPro;
using UnityEngine;
using Zenject;

public class LevelIDView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [Inject]
    private void Construct(SelectedLevel id) => _text.text = $"Level {id.ID}";
}