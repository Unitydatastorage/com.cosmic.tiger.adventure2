using UnityEngine;

public class PolicyAcceptView : MonoBehaviour
{
    private const string ShowedKey = "PolicyShowed";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(ShowedKey)) Destroy(gameObject);
    }

    public void Close()
    {
        PlayerPrefs.SetInt(ShowedKey, 1);
        Destroy(gameObject);
    }
}