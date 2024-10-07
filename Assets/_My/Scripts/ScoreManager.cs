using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public int scoreCounter = 0;

    List<int> scoreList = new();
    [SerializeField] List<TextMeshProUGUI> scoreTextList;
    [SerializeField] TextMeshProUGUI scoreTextExtra;
    int selectedHighscore;

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
                    selectedHighscore = i;
                    break;
                }
            }
            else
            {
                scoreList.Add(scoreCounter);
                selectedHighscore = i + 1;
            }
        }

        for (int i = 0; i < scoreTextList.Count; i++)
        {
            if (selectedHighscore == i)
            {
                scoreTextList[i].fontStyle = (FontStyles)FontStyle.Bold;
            }
            scoreTextList[i].text = i + ". " + scoreList[i];
        }
        if (selectedHighscore >= scoreTextList.Count)
        {
            scoreTextExtra.fontStyle = (FontStyles)FontStyle.Bold;
            scoreTextExtra.text = selectedHighscore + ". " + scoreList[selectedHighscore];
        }
    }
}
