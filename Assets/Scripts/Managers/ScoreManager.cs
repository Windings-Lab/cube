using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScoreManager
{
    private static GameObject scoreText;
    private static int score;
    public static int Score
    {
        get
        {
            return score;
        }
    }

    public static void AddPoints()
    {
        score += 50;
        scoreText.GetComponent<Text>().text = "SCORE: " + score;
    }

    static ScoreManager()
    {
        scoreText = GameObject.Find("ScoreText");
        score = 0;
    }
}
