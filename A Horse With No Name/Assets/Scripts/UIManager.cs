using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
public class UIManager : MonoBehaviour
{
    public async void GoToGame()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerMenu>().playClickSFX();
        AudioListener listener = Camera.main.GetComponent<AudioListener>();
        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        SceneManager.UnloadSceneAsync("Leaderboard");

        while (listener != null || eventSystem != null)
        {
            await Task.Delay(100); 
        }

        GameObject.FindGameObjectWithTag("HideObjects").GetComponent<HideSceneManager>().ShowObjects();
    }
    
    public void GoToLeaderboards ()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().playClickSFX();
        GameObject.FindGameObjectWithTag("HideObjects").GetComponent<HideSceneManager>().HideObjects();
        SceneManager.LoadSceneAsync("Leaderboard", LoadSceneMode.Additive);
    }
}
