using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
public class UIManager : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.UnloadSceneAsync("Leaderboard");
        Time.timeScale = 1;
    }
    
    public void GoToLeaderboards ()
    {
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().playClickSFX();
        SceneManager.LoadSceneAsync("Leaderboard", LoadSceneMode.Additive);
    }
}
