using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public int currentScore;

    public TextMeshProUGUI scoreOnPanel;
    public TextMeshProUGUI bestScoreOnPanel;

    private void Awake()
    {
        DelegatesHandler.MeteorDestroyed += IncreaseScore;
    }

    private void Start()
    {
        scoreOnPanel.text = "Score 0";
        bestScoreOnPanel.text = "Best Score " + PlayerPrefs.GetInt("NewBestScore", 0).ToString();
    }

    public void IncreaseScore()
    {
        currentScore ++;
        currentScoreText.text = currentScore.ToString();
        scoreOnPanel.text = "Score " + currentScore.ToString();

        if (currentScore > PlayerPrefs.GetInt("NewBestScore", 0))
        {
            PlayerPrefs.SetInt("NewBestScore", currentScore);
            bestScoreOnPanel.text = "Best Score " + PlayerPrefs.GetInt("NewBestScore", 0).ToString();
        }
    }


}
