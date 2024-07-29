using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private ItemIconInit _itemIconInit;
    [SerializeField] private ItemSelect _itemSelect;
    [SerializeField] private ItemDeselect _itemDeselect;
    [SerializeField] private MatchFinder _matchFinder;

    public override void InstallBindings()
    {
        Container.
            Bind<ItemIconInit>().
            FromInstance(_itemIconInit).
            AsSingle().
            NonLazy();

        Container.
            Bind<ItemSelect>().
            FromInstance(_itemSelect).
            AsSingle().
            NonLazy();

        Container.
            Bind<ItemDeselect>().
            FromInstance(_itemDeselect).
            AsSingle().
            NonLazy();

        Container.
            Bind<MatchFinder>().
            FromInstance(_matchFinder).
            AsSingle().
            NonLazy();
    }
}