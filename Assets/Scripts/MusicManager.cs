using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;
    private float currentVolume = 1f; // Default volume (1 = 100%)

    public static MusicManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across levels
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
            return;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on MusicManager!");
            return;
        }

        audioSource.loop = true; // Ensure the music loops
        audioSource.Play(); // Start playing if not already playing
    }

    public void SetVolume(float volume)
    {
        currentVolume = volume;
        audioSource.volume = currentVolume;
        Debug.Log("Music Volume: " + currentVolume);
    }
}