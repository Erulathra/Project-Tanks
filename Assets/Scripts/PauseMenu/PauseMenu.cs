using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    
    private bool isVisible = false;
    private void Update()
    {
        if (!IsPauseButtonReleasedThisFrame()) return;
        
        if (isVisible)
            Resume();
        else
            Pause();
    }

    private static bool IsPauseButtonReleasedThisFrame()
    {
        return Gamepad.current.startButton.wasReleasedThisFrame || Keyboard.current.escapeKey.wasReleasedThisFrame;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isVisible = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isVisible = true;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneLoader.LoadMenuWithTransition();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
