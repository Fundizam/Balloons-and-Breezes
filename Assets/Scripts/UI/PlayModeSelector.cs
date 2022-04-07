using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayModeSelector : MonoBehaviour
{
    [SerializeField] private Image _mainMenuPanel;
    [SerializeField] private Image _levelPanel;
    public string ArcadeLevelName;

    public void OpenLevelPanelInStoryMode()
    {
        _mainMenuPanel.gameObject.SetActive(false);
        _levelPanel.gameObject.SetActive(true);
    }

    public void ArcadeModeLevel()
    {
        SceneManager.LoadScene(ArcadeLevelName);
    }
}