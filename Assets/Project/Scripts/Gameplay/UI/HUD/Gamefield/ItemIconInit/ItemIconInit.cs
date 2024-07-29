using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemIconInit : MonoBehaviour
{
    [SerializeField] private ItemConfig _config;

    private List<Sprite> _avaibleIcons;

    [Inject]
    private void Construct()
    {
        _avaibleIcons = new List<Sprite>();

        foreach (var sprite in _config.Sprites)
        {
            _avaibleIcons.Add(sprite);
            _avaibleIcons.Add(sprite);
        }
    }

    public Sprite GetIcon()
    {
        var randomIndex = Random.Range(0, _avaibleIcons.Count);
        var sprite = _avaibleIcons[randomIndex];
        _avaibleIcons.RemoveAt(randomIndex);

        return sprite;
    }
}