using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MusicToggle : MonoBehaviour
{
    private void Start()
    {
        var toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(BackgroundMusic.Toggle);
        toggle.isOn = BackgroundMusic.Enabled;
    }
}