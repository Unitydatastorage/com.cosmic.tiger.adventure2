using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public event Action<Item> Selected;

    [SerializeField] private float _collapseDuration;
    [SerializeField] private Ease _collapseEase;

    [SerializeField] private float _appearanceDuration;
    [SerializeField] private Ease _appearanceEase;

    public void Select(Item item, Action callback)
    {
        StartAnimation(item.transform, () =>
        {
            item.IconView.gameObject.SetActive(true);
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
            OnComplete(() =>
            {
                Selected?.Invoke(item);
                callback?.Invoke();
            });
    }
}