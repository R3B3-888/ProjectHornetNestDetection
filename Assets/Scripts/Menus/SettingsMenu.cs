using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SettingsMenu : MonoBehaviour
{
    public static void OnClick_Back()
    {
        SimulationMenu.pauseMenu.SetActive(true);
        SimulationMenu.settingsMenu.SetActive(false);
        // SceneManager.Load
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
