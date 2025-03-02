using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

        // Set the slider's default value to the current volume
        if (MusicManager.Instance != null)
        {
            slider.value = MusicManager.Instance.GetComponent<AudioSource>().volume;
        }

        slider.onValueChanged.AddListener(SetMusicVolume);
    }

    private void SetMusicVolume(float volume)
    {
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.SetVolume(volume);
        }
    }
}