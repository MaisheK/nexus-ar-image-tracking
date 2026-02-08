using UnityEngine;
using UnityEngine.Video;

public class SeparateAudioVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    void Start()
    {
        videoPlayer.audioOutputMode = VideoAudioOutputMode.None;
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        PlayBoth();
    }

    public void PlayBoth()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
            audioSource.Play();
        }
    }

    public void PauseBoth()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            audioSource.Pause();
        }
    }
}
