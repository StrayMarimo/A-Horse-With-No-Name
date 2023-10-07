using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField]
    private TMP_Text scoreText;
    public float score = 0;
    public GameObject Player;
    
    public bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        score = Mathf.Round(Player.transform.position.x * 100.0f) * 0.01f; 
        scoreText.text = string.Format("{0:0.##}", score);
    }
}
