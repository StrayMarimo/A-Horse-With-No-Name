using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField]
    private TMP_Text scoreText;
    private float score = 0;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        score = Mathf.Round(Player.transform.position.x * 100.0f) * 0.01f; 
        scoreText.text = string.Format("{0:0.##}", score);
    }
}
