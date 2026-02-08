using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class Track : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public VideoPlayer video;
    public AudioSource audioSource;
    private Slider tracking;
    private bool slide = false;

    void Start()
    {
        tracking = GetComponent<Slider>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        slide = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Calculate new time based on slider value
        double newTime = tracking.value * video.length;

        // Seek both video and audio to the same time
        video.time = newTime;
        audioSource.time = (float)newTime;

        slide = false;
    }

    void Update()
    {
        if (!slide && video.isPrepared && video.frameCount > 0)
        {
            tracking.value = (float)(video.time / video.length);
        }
    }
}
