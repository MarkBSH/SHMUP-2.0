using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public int scoreCounter = 0;

    List<int> scoreList = new();

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        scoreText.text = "SCORE: " + scoreCounter;
    }

    public void AddScore(int score)
    {
        scoreCounter += score;
        scoreText.text = "SCORE: " + scoreCounter;
    }

    public void LoadHighscores()
    {
        for (int i = 0; i < scoreList.Count + 1; i++)
        {
            if (i <= scoreList.Count)
            {
                if (scoreCounter > scoreList[i])
                {
                    scoreList.Insert(i, scoreCounter);
                    break;
                }
            }
            else
            {
                scoreList.Add(scoreCounter);
            }
        }

        for (int i = 0; i < 5; i++)
        {
            
        }
    }
}
