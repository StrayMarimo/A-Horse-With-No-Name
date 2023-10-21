using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        
        if(PlayerPrefs.HasKey("audioVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetAudioVolume();
        }
    }

    public void SetAudioVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("audioVolume", volume);
        print("hangaw");
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("audioVolume");

        SetAudioVolume();
    }
}
