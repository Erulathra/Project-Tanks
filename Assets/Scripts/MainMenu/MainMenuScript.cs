using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionsDropdown;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullscreenToggle;
    private Resolution[] resolutions;
    
    public void Settings()
    {
        GetAvialableResolutions();
    }

    public void Start()
    {
        SetSavedSettings();
    }

    private void GetAvialableResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();

        List<string> resolutionOptions = new List<string>();
        foreach (var resolution in resolutions)
        {
            resolutionOptions.Add(resolution.height + "x" + resolution.width + " " + resolution.refreshRate + "Hz");
        }

        resolutionsDropdown.AddOptions(resolutionOptions);
    }

    private void SetSavedSettings()
    {
        int qualityIndex = PlayerPrefs.GetInt("QualitySettings");
        int resolutionWidth = PlayerPrefs.GetInt("ResolutionWidth");
        int resolutionHeight = PlayerPrefs.GetInt("ResolutionHeight");
        bool isFullscreen = PlayerPrefs.GetInt("FullScreen") == 1;
        
        Screen.fullScreen = isFullscreen;
        fullscreenToggle.isOn = isFullscreen;
        Debug.Log("Fullscreen: " + isFullscreen);
        
        QualitySettings.SetQualityLevel(qualityIndex);
        qualityDropdown.value = qualityIndex;
        Debug.Log("QualityIndex: " + qualityIndex);
        
        if (resolutionHeight > 0 && resolutionWidth > 0)
        {
            Debug.Log("Resolution: " + resolutionWidth+"x"+resolutionHeight);
            Screen.SetResolution(resolutionWidth, resolutionHeight, Screen.fullScreen);
        }
        else
        {
            Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen);
        }
    }

    public void LoadLobby()
    {
        SceneLoader.TryLoadSceneWithTransition(SceneLoader.Scene.PlayerLobby);
    }

    public void Quit()
    {
        Application.Quit(0);
    }

    public void SetQualitySettings(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualitySettings", qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        PlayerPrefs.SetInt("FullScreen", ((isFullScreen) ? 1 : 0));
    }

    public void SetResolution(int resolutionIndex)
    {
        var resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionWidth", resolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", resolution.height);
    }
    
}
