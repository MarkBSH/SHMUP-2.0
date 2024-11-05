using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager m_Instance;
    public static ScoreManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<ScoreManager>();
                if (m_Instance == null)
                {
                    GameObject _obj = new()
                    {
                        name = typeof(ScoreManager).Name
                    };
                    m_Instance = _obj.AddComponent<ScoreManager>();
                }
            }
            return m_Instance;
        }
    }

    TextMeshProUGUI scoreText;
    public int scoreCounter = 0;

    List<int> scoreList = new();
    [SerializeField] List<TextMeshProUGUI> scoreTextList;
    [SerializeField] TextMeshProUGUI scoreTextExtra;
    int selectedHighscore;
    GameObject scoreObject;

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreObject = GameObject.Find("ScorePanel");
        scoreObject.SetActive(false);
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
        scoreObject.SetActive(true);
        for (int i = 0; i < scoreList.Count + 1; i++)
        {
            if (i < scoreList.Count)
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
                break;
            }
        }

        for (int i = 0; i < scoreTextList.Count; i++)
        {
            if (selectedHighscore == i)
            {
                scoreTextList[i].fontStyle = (FontStyles)FontStyle.Bold;
            }
            scoreTextList[i].text = i + 1 + ". " + scoreList[i];
        }
        if (selectedHighscore >= scoreTextList.Count)
        {
            scoreTextExtra.fontStyle = (FontStyles)FontStyle.Bold;
            scoreTextExtra.text = selectedHighscore + ". " + scoreList[selectedHighscore];
        }
    }
}
