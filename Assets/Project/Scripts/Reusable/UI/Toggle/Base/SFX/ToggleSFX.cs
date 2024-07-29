using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleSFX : MonoBehaviour
{
    private void Awake() => GetComponent<Toggle>().onValueChanged.AddListener((bool _) => SFX.Play());
}