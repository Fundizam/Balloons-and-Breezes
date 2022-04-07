using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelChecker : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private Sprite _lockImage;
    [SerializeField] private Sprite _levelImage;
    const string LEVEL_PROGRESS = "LevelProgress";
    private Button _button;
    private Image _image;
    private void Start()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        CheckForLevelUnlock();
    }
    private void CheckForLevelUnlock()
    {
        if (_level > PlayerPrefs.GetInt(LEVEL_PROGRESS))
        {
            _button.interactable = false;
            _image.sprite = _lockImage;
        }
        else
        {
            _button.interactable = true;
            _image.sprite = _levelImage;
        }
    }
}
