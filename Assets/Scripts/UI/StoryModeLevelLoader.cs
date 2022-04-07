using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StoryModeLevelLoader : MonoBehaviour
{
    [SerializeField] private Image _mainMenuPanel;
    [SerializeField] private Image _levelPanel;

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void ReturnToMainMenu()
    {
        _mainMenuPanel.gameObject.SetActive(true);
        _levelPanel.gameObject.SetActive(false);
    }
}