using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public float score;
    public float scoreBonus;

    // Update is called once per frame
    void Update()
    {
        score = player.position.y;
        score += scoreBonus;
        scoreText.text = "Score: " + score.ToString("0");
    }

    public void AddScore(float pointsToAdd)
    {
        scoreBonus += pointsToAdd;
    }

    public void ResetScore()
    {
        scoreBonus = 0;
    }
}
