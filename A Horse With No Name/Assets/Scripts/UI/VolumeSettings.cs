using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;

    [SerializeField]
    private GameObject toggleDayButton;

    [SerializeField]
    private GameObject toggleNightButton;

    [SerializeField]
    private MainMenu mainMenuScript;
    void Awake()
    {
        if (PlayerPrefs.GetInt("isDay") == 0)
        {
            toggleNightButton.SetActive(true);
            toggleDayButton.SetActive(false);
        }
        else
        {
            toggleDayButton.SetActive(true);
            toggleNightButton.SetActive(false);
        }
    }
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
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("audioVolume");
        SetAudioVolume();
    }


    public void ToggleMode()
    {
        GameObject.FindGameObjectWithTag("Click").GetComponent<AudioSource>().Play();
        if (PlayerPrefs.GetInt("isDay") == 0)
        {
            toggleNightButton.SetActive(false);
            toggleDayButton.SetActive(true); 
            PlayerPrefs.SetInt("isDay", 1);
        }
        else
        {
            toggleDayButton.SetActive(false);
            toggleNightButton.SetActive(true); 
            PlayerPrefs.SetInt("isDay", 0);
        }

        mainMenuScript.setBG();
    }
}
