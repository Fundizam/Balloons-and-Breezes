using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSaver : MonoBehaviour
{
    const string HIGH_SCORE = "HighScore";
    [SerializeField] private TextMeshProUGUI _highScoreText;
    private ArcadeModeManager _arcadeModeManager;
    private string HighScoreText = "High Score: ";
    private void Awake()
    {
        _arcadeModeManager = GetComponent<ArcadeModeManager>();
    }

    private void Start()
    {
        CreateHighScore();
    }
    public void SetHighScore()
    {
        int score = _arcadeModeManager.GetScore();
        if (score < PlayerPrefs.GetInt(HIGH_SCORE))
        {
            _highScoreText.text = HighScoreText + PlayerPrefs.GetInt(HIGH_SCORE);
        }
        else
        {
            PlayerPrefs.SetInt(HIGH_SCORE, score);
            _highScoreText.text = HighScoreText + PlayerPrefs.GetInt(HIGH_SCORE);
        }
    }

    private void CreateHighScore()
    {
        if (!PlayerPrefs.HasKey(HIGH_SCORE))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
        }
    }
}
