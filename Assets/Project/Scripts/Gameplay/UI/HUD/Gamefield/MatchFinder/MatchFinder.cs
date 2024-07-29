using System;
using UnityEngine;
using Zenject;

public class MatchFinder : MonoBehaviour
{
    public event Action AllMatched;

    private Item _lastItem;

    private ItemSelect _itemSelect;
    private ItemDeselect _itemDeselect;

    private const int MatchesToWin = 6;
    private int _matches;

    [Inject]
    private void Construct(ItemSelect itemSelect, ItemDeselect deselect)
    {
        _itemSelect = itemSelect;
        _itemDeselect = deselect;

        _itemSelect.Selected += Check;
    }

    private void Check(Item second)
    {
        if (_lastItem == null)
        {
            _lastItem = second;
            return;
        }

        if (_lastItem.IconView.sprite.name != second.IconView.sprite.name)
        {
            _lastItem.Deselect();
            second.Deselect();
        }
        else
        {
            _lastItem.Solve();
            second.Solve();
            _matches++;

            if (_matches == MatchesToWin) AllMatched?.Invoke();
        }

        _lastItem = null;
    }

    private void OnDestroy() => _itemSelect.Selected -= Check;
} 