using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "ItemInitinalizerConfig",
    menuName = "Project/Gameplay/UI/Gamefield/ItemInitializer/Config")]
public class ItemConfig : ScriptableObject
{
    public IReadOnlyCollection<Sprite> Sprites => _sprites;
    [SerializeField] private List<Sprite> _sprites;
}