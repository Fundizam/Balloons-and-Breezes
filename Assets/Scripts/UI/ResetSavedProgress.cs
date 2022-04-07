using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetSavedProgress : MonoBehaviour
{
    const string LEVEL_PROGRESS = "LevelProgress";
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(ResetProgress);
    }

    private void ResetProgress()
    {
        PlayerPrefs.SetInt(LEVEL_PROGRESS, 1);
    }
}
