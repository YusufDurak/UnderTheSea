using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    [SerializeField] private AudioClip level1Music; // Music for Level 1
    [SerializeField] private AudioClip level2Music; // Music for Level 2

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across all scenes

            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("No AudioSource found on MusicManager!");
                return;
            }

            audioSource.loop = true; // Make sure the music loops
            audioSource.Play(); // Start playing the music
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate music managers
        }
    }
}
