using UnityEngine;
using Zenject;

public class WinView : MonoBehaviour
{
    [SerializeField] private GameObject _view;

    private MatchFinder _matchFinder;

    [Inject]
    private void Construct(MatchFinder matchFinder)
    {
        _matchFinder = matchFinder;
        _matchFinder.AllMatched += Show;
    }

    private void Show() => _view.SetActive(true);
    private void OnDestroy() => _matchFinder.AllMatched -= Show;
}