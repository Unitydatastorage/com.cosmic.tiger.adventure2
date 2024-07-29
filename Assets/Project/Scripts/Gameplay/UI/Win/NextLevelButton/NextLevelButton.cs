using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private GameObject _exitButton;

    [Inject] private readonly SelectedLevel _selectedLevel;

    private void Awake()
    {
        if(_selectedLevel.ID >= 15)
        {
            _exitButton.SetActive(true);
            Destroy(gameObject);
            return;
        }
        GetComponent<Button>().onClick.AddListener(Next);
    }

    private void Next()
    {
        _selectedLevel.ID++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}