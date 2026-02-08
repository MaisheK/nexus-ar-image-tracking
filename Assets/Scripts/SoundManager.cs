using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;
    private AudioSource bgMusicSource;

    void Start()
    {
        // Get reference to background music audio source
        BackgroundMusic bgMusic = FindObjectOfType<BackgroundMusic>();
        if (bgMusic != null)
            bgMusicSource = bgMusic.GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        ApplyMute();
    }

    public void OnButtonPress()
    {
        muted = !muted;
        ApplyMute();
        Save();
        UpdateButtonIcon();
    }

    private void ApplyMute()
    {
        if (bgMusicSource != null)
            bgMusicSource.mute = muted;
    }

    private void UpdateButtonIcon()
    {
        soundOnIcon.enabled = !muted;
        soundOffIcon.enabled = muted;
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
