using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimulationMenu : MonoBehaviour
{
    public static bool isGamePaused = false, inInteractiveMode = false;
    public static GameObject pauseMenu, settingsMenu;

    private void Start() {
        GameObject canvas = GameObject.Find("Canvas");
        pauseMenu = canvas.transform.Find("PauseMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
                
            if(settingsMenu.activeInHierarchy)
                SettingsMenu.OnClick_Back();
            else if(isGamePaused)
                Resume(); 
            else
                Pause();
        }
        if(Input.GetKeyDown(KeyCode.I))
            inInteractiveMode ^= true;
    }

    public void Resume()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        isGamePaused = true;
        Time.timeScale = 0f; // freeze time
        pauseMenu.SetActive(true);
    }

    public void OnClick_LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void OnClick_Settings()
    {
        Debug.Log("Settings Menu");
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void OnClick_Quit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
