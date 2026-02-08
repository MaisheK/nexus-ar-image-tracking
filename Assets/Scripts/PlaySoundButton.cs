using UnityEngine;
using UnityEngine.UI;

public class PlaySoundButton : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayCurrentSound);
    }

    void PlayCurrentSound()
    {
        if (SmartObserverHandler.currentAudioSource != null &&
            SmartObserverHandler.currentAudioSource.clip != null &&
            !SmartObserverHandler.currentAudioSource.isPlaying)
        {
            SmartObserverHandler.currentAudioSource.Play();
        }
    }
}
