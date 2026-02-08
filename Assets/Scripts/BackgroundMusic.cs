using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    private AudioSource audioSource;

    private void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(gameObject);

            // Get AudioSource and make sure it loops
            audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.loop = true;
                audioSource.playOnAwake = true;

                // Start playing the music
                if (!audioSource.isPlaying)
                    audioSource.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
