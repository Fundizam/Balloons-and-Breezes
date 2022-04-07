using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameController : MonoBehaviour
{
    [SerializeField] private SceneNamesData _sceneNamesData;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(_sceneNamesData.MainMenuSceneName);
    }

}
