using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    private static AudioSource _audioSource;

    private const string EnabledKey = "MusicEnabled";
    public static bool Enabled => _enabled;
    private static bool _enabled;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey(EnabledKey)) Toggle(PlayerPrefs.GetInt(EnabledKey) == 1);
        else Toggle(true);
    }

    public static void Play()
    {
        if (!_enabled) return;
        if(_audioSource.clip == null) return;
        _audioSource.Play();
    }

    public static void Toggle(bool enable)
    {
        _enabled = enable;
        _audioSource.enabled = enable;
        Save();
    }

    private static void Save() => PlayerPrefs.SetInt(EnabledKey, _enabled ? 1 : 0);
}