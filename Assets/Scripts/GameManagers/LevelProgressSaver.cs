using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgressSaver : MonoBehaviour
{
    public string LevelProgress;
    const string LEVEL_PROGRESS = "LevelProgress";

    private void Start()
    {
        LevelProgress = LEVEL_PROGRESS;
        CreateLastLevelCompletedPref();
    }

    public void UpdateLevelProgressOnLevelComplete()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < PlayerPrefs.GetInt(LEVEL_PROGRESS))
        {
            return;
        }
        PlayerPrefs.SetInt(LEVEL_PROGRESS, currentSceneIndex + 1);
    }

    public void UpdateLevelProgressOnGameOver()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < PlayerPrefs.GetInt(LEVEL_PROGRESS))
        {
            return;
        }
        PlayerPrefs.SetInt(LEVEL_PROGRESS, currentSceneIndex);
    }

    private void CreateLastLevelCompletedPref()
    {
        if (!PlayerPrefs.HasKey(LEVEL_PROGRESS))
        {
            PlayerPrefs.SetInt(LEVEL_PROGRESS, 1);
        }
    }
}
