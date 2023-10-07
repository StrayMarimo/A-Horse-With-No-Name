using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject Score;
    public GameObject ScoreManager;
    List<HighScoreEntry> scores = new List<HighScoreEntry>();
    private bool isDead = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.R) && isDead)
            {
                Destroy(GameObject.FindGameObjectWithTag("Horse"));
                SceneManager.LoadSceneAsync("Main");
            }
    }
    async void OnCollisionEnter2D(Collision2D otherObj)
    {
        if (otherObj.gameObject.tag == "Ground") {
            await Task.Delay(300);
            float score = Score.GetComponent<Score>().score;
            print(PlayerPrefs.GetString("PlayerName")+ " died with score: " + score);
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().playPlayerDiedSFX();
            addScore(PlayerPrefs.GetString("PlayerName"), score);
            isDead = true;
        }
    
    }

    void addScore(string entryName, float entryScore) {
        scores = XMLManager.instance.LoadScores();
        scores.Add(new HighScoreEntry { name = entryName, score = entryScore });
        XMLManager.instance.SaveScores(scores);
    }
}
