using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject Score;
    public GameObject YouDied;
    private Score scoreScript;

    List<HighScoreEntry> scores = new List<HighScoreEntry>();
    void Start()
    {
        scoreScript = Score.GetComponent<Score>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && scoreScript.isDead)
            {
                SceneManager.LoadSceneAsync("Main");
            }
    }
    async void OnCollisionEnter2D(Collision2D otherObj)
    {
        if (otherObj.gameObject.tag == "Ground" && !scoreScript.isDead) {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().playPlayerDiedSFX();
            await Task.Delay(300);
            float score = scoreScript.score;
            scoreScript.isDead = true;
            PlayerPrefs.SetInt("isDead", 1); 
            print(PlayerPrefs.GetString("PlayerName")+ " died with score: " + score);
            YouDied.GetComponent<GameOver>().onGameOver();
            YouDied.SetActive(true);
            addScore(PlayerPrefs.GetString("PlayerName"), score);
        }
    
    }

    void addScore(string entryName, float entryScore) {
        scores = XMLManager.instance.LoadScores();
        scores.Add(new HighScoreEntry { name = entryName, score = entryScore });
        XMLManager.instance.SaveScores(scores);
    }
}
