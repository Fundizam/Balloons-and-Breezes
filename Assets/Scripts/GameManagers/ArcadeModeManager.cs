using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ArcadeModeManager : MonoBehaviour
{
    [Header("ArcadeModeCanvas")]
    [SerializeField] private Image _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _uIScoreText;
    [SerializeField] private TextMeshProUGUI _postGameScoreText;
    [Space]
    [SerializeField] private SceneNamesData _sceneNamesData;

    private string _scoreText = "Score: ";
    private bool _isGameOver = false;
    private int _currentSceneIndex;
    private int _score = 0;

    private void Start()
    {
        
        if (Time.timeScale == 0)
        {
            UnpauseGame();
        }
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _uIScoreText.text = _scoreText + _score.ToString();
    }

    private void Update()
    {
        CheckIfGameOver();
    }

    private void CheckIfGameOver()
    {
        if (_isGameOver == true)
        {
            _gameOverPanel.gameObject.SetActive(true);
            _postGameScoreText.text = _scoreText + _score.ToString();
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    public void SetIsGameOver(bool gameOverParam)
    {
        _isGameOver = gameOverParam;
    }

    public void UpdateScore()
    {
        _score++;
        _uIScoreText.text = _scoreText + _score.ToString();
    }

    public int GetScore()
    {
        return _score;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(_sceneNamesData.MainMenuSceneName);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }
}
