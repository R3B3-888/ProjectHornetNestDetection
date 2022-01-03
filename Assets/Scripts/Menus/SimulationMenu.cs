using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimulationMenu : MonoBehaviour
{
    public static bool inInteractiveMode = false;
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
            else if(DataBase.Settings.GamePause)
                Resume(); 
            else
                Pause();
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            MapGenerator.UpdateOn ^= true;
            inInteractiveMode ^= true;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SimulationScene");
        }
    }

    public void Resume()
    {
        DataBase.Settings.GamePause = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        MapGenerator.UpdateOn = false; 
    }

    public void Pause()
    {
        DataBase.Settings.GamePause = true;
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
