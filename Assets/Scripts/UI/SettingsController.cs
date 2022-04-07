using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SettingsController : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public string MasterVolumeMixer;
    public string SoundEffectsVolumeMixer;
    const string MASTER_VOLUME = "MasterVolume";
    const string SOUND_VOLUME = "SoundEffectsVolume";
    [SerializeField] private Image _mainMenuPanel;
    [SerializeField] private Image _settingsMenuPanel;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _sFXVolumeSlider;

    private void Start()
    {
        CreateSoundSettings();
        LoadVolumeSettings();
        LoadVolumeSettingOnSliders();
    }
    private void CreateSoundSettings()
    {
        if (!PlayerPrefs.HasKey(MASTER_VOLUME) && !PlayerPrefs.HasKey(SOUND_VOLUME))
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME, 0);
            PlayerPrefs.SetFloat(SOUND_VOLUME, 0);
        }
    }
    private void LoadVolumeSettings()
    {
        AudioMixer.SetFloat(MasterVolumeMixer, PlayerPrefs.GetFloat(MASTER_VOLUME));
        AudioMixer.SetFloat(SoundEffectsVolumeMixer, PlayerPrefs.GetFloat(SOUND_VOLUME));
    }

    private void LoadVolumeSettingOnSliders()
    {
        _masterVolumeSlider.value = PlayerPrefs.GetFloat(MASTER_VOLUME);
        _sFXVolumeSlider.value = PlayerPrefs.GetFloat(SOUND_VOLUME);
    }

    public void ResetSlidersOnCancel()
    {
        _masterVolumeSlider.value = PlayerPrefs.GetFloat(MASTER_VOLUME);
        _sFXVolumeSlider.value = PlayerPrefs.GetFloat(SOUND_VOLUME);
    }
    public void SaveChanges()
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME, _masterVolumeSlider.value);
        PlayerPrefs.SetFloat(SOUND_VOLUME, _sFXVolumeSlider.value);
    }
    public void OpenSettingsMenu()
    {
        _mainMenuPanel.gameObject.SetActive(false);
        _settingsMenuPanel.gameObject.SetActive(true);
    }
    public void ReturnToMainMenu()
    {
        _mainMenuPanel.gameObject.SetActive(true);
        _settingsMenuPanel.gameObject.SetActive(false);
    }
    public void SetMasterAudioMixerVolume()
    {
        AudioMixer.SetFloat(MasterVolumeMixer, _masterVolumeSlider.value);
    }
    public void SetSFXAudioMixerVolume()
    {
        AudioMixer.SetFloat(SoundEffectsVolumeMixer, _sFXVolumeSlider.value);
    }
}