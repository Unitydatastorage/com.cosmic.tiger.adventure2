using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SFXToggle : MonoBehaviour
{
    private void Start()
    {
        var toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(SFX.Toggle);
        toggle.isOn = SFX.Enabled;
    }
}