using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class Item : MonoBehaviour
{
    public Image IconView => _iconView;
    [SerializeField] private Image _iconView;

    private ItemSelect _select;
    private ItemDeselect _deselect;

    public bool Selected { get; private set; }
    public bool Solved { get; private set; }

    [Inject]
    private void Construct(ItemIconInit itemIconInit, ItemSelect select, ItemDeselect deselect)
    {
        _iconView.sprite = itemIconInit.GetIcon();
        _iconView.SetNativeSize();
        _iconView.transform.localPosition = Vector3.zero;
        _iconView.gameObject.SetActive(false);
        _select = select;
        _deselect = deselect;
    }

    private void Awake() => GetComponent<Button>().onClick.AddListener(TrySelect);

    private void TrySelect()
    {
        if (!Selected) Select();
    }

    public void Solve() => Solved = true;
    public void Select() => _select.Select(this, () => Selected = true);
    public void Deselect() => _deselect.Deselect(this, () => Selected = false);
}