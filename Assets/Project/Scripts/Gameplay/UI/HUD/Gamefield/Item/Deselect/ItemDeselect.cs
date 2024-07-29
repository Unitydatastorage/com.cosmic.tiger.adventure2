using DG.Tweening;
using System;
using UnityEngine;

public class ItemDeselect : MonoBehaviour
{
    [SerializeField] private float _collapseDuration;
    [SerializeField] private Ease _collapseEase;

    [SerializeField] private float _appearanceDuration;
    [SerializeField] private Ease _appearanceEase;

    public void Deselect(Item item, Action callback)
    {
        StartAnimation(item.transform, () =>
        {
            item.IconView.gameObject.SetActive(false);
            EndAnimation(item, callback);
        });
    }

    private void StartAnimation(Transform transform, TweenCallback callback)
    {
        transform.DOScale(0, _collapseDuration).SetEase(_collapseEase).OnComplete(callback);
    }

    private void EndAnimation(Item item, Action callback)
    {
        item.transform.DOScale(Vector3.one, _appearanceDuration).
            SetEase(_appearanceEase).
            OnComplete(() => callback?.Invoke());
    }
}