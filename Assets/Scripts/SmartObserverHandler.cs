using UnityEngine;
using Vuforia;

public class SmartObserverHandler : MonoBehaviour
{
    public AudioSource audioSource;
    public static AudioSource currentAudioSource; // Shared among all

    private DefaultObserverEventHandler observerHandler;

    void Awake()
    {
        observerHandler = GetComponent<DefaultObserverEventHandler>();

        if (observerHandler != null)
        {
            observerHandler.OnTargetFound.AddListener(OnTrackingFound);
            observerHandler.OnTargetLost.AddListener(OnTrackingLost);
        }
    }

    void OnTrackingFound()
    {
        currentAudioSource = audioSource;
    }

    void OnTrackingLost()
    {
        // Clear only if this one was the current source
        if (currentAudioSource == audioSource)
            currentAudioSource = null;
    }
}
