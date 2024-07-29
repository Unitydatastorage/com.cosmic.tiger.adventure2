using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSFX : MonoBehaviour
{
    private void Awake() => GetComponent<Button>().onClick.AddListener(SFX.Play);
}