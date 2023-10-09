using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class GameOver : MonoBehaviour
{
    // [SerializeField]
    public TMP_Text scoreText;
    //  [SerializeField]
    public TMP_Text highScoreText;
    // [SerializeField]
    public TMP_Text nameText;
    // [SerializeField]
    public TMP_Text RankText;
    public GameObject Score;

    private AudioManager audioManager;


    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void onPlayAgain()
    {
        audioManager.playClickSFX();
        gameObject.SetActive(false);
        SceneManager.LoadSceneAsync("Main");
    }

    public void onQuit()
    {
        audioManager.playClickSFX();
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void onGameOver()
    {
        float score = Score.GetComponent<Score>().score;
        highScoreText.text = "Best: " + string.Format("{0:0.##}", PlayerPrefs.GetFloat("HighScore"));
        nameText.text = PlayerPrefs.GetString("PlayerName");
        scoreText.text = "You ran an incredible " + string.Format("{0:0.##}", score) + " meters without falling";

        if (score > PlayerPrefs.GetFloat("HighScore"))
        {
            RankText.text = "New High Score!";
            highScoreText.text = "Best: " + string.Format("{0:0.##}", score); 
        }
        else if (score > PlayerPrefs.GetFloat("LowScore"))
        {
            RankText.text = "Congratulations! You made it in our top 10. Check out the leaderboard to see where you rank!";
        } else 
        {
            RankText.text = "You didn't make it into our top 10. Try again to see if you can make it!";
        }
    }

}

