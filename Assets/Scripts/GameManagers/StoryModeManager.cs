using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryModeManager : MonoBehaviour
{
    [Header("StoryModeCanvas")]
    [SerializeField] private Image _gameOverPanel;
    [SerializeField] private Image _levelCompletePanel;
    [SerializeField] private Slider _progressBar;
    [Space]
    [SerializeField] private LevelTimerData _levelTimerData;
    [SerializeField] private SceneNamesData _sceneNamesData;

    private bool _isGameOver = false;
    private bool _isLevelComplete = false;
    private int _currentSceneIndex;
    private float _progressBarStartValue;

    private void Start()
    {
        
        if (Time.timeScale == 0)
        {
            UnpauseGame();
        }
        _progressBar.value = _progressBarStartValue;
        _progressBar.maxValue = _levelTimerData.LevelTime;
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        ProgressOnSlider();
        CheckIfGameOver();
    }

    private void ProgressOnSlider()
    {
        if (_isGameOver == false && _isLevelComplete == false)
        {
            if (_progressBar.value < _progressBar.maxValue)
            {
                _progressBar.value += Time.deltaTime;
            }
            if (_progressBar.value >= _progressBar.maxValue)
            {
                _progressBar.value = _progressBar.maxValue;
                LevelComplete();
            }
        }
    }

    private void LevelComplete()
    {
        _isLevelComplete = true;
        _levelCompletePanel.gameObject.SetActive(true);
        PauseGame();
    }

    private void CheckIfGameOver()
    {
        if (_isGameOver == true)
        {
            _gameOverPanel.gameObject.SetActive(true);
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
    }

    public void SetIsGameOver(bool gameOverParam)
    {
        _isGameOver = gameOverParam;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(_sceneNamesData.MainMenuSceneName);
    }
}