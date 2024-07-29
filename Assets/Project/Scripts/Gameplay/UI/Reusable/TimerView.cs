using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private MatchFinder _matchFinder;

    private bool _finished = false;

    [Inject]
    private void Construct(MatchFinder matchFinder)
    {
        _matchFinder = matchFinder;
        _matchFinder.AllMatched += Stop;
    }
    private void Start() => AddSecond();

    private void Stop() => _finished = true;

    private async void AddSecond()
    {
        await Task.Delay(1000);

        if (_text == null) return;
        if (_finished) return;

        var textComponent = _text;
        var timeText = textComponent.text;

        var timeParts = timeText.Split(':');

        if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int minutes) && int.TryParse(timeParts[1], out int seconds))
        {
            seconds++;
            if (seconds >= 60)
            {
                seconds = 0;
                minutes++;
            }
            textComponent.text = $"{minutes:D2}:{seconds:D2}";
        }
        else
        {
            Debug.LogError($"Неверный формат времени: {timeText}");
        }

        AddSecond();
    }

    private void OnDestroy() => _matchFinder.AllMatched -= Stop;
}