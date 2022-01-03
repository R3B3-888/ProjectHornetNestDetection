using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public static void OnClick_Back()
    {
        SimulationMenu.pauseMenu.SetActive(true);
        SimulationMenu.settingsMenu.SetActive(false);
        // SceneManager.Load
    }
    public void Reload()
    {
        SceneManager.LoadScene("SimulationScene");
        SceneManager.LoadScene("MenuScene");
    }
    // xSize
    // void SetTerrainWidth() {}
    // void SetTerrainLength() {}
    // void SetSeed(){}
    // void SetScale(){}
    // void SetLacunarity() {}
    // void SetForestSize() {}
    // void SetSpaceBetweenTrees() {}
    // void SetNestNumber() {}

}
