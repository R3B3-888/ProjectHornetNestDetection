using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClick_LoadSimulationScene()
    {
        SceneManager.LoadScene("SimulationScene");
    }

    public void OnClick_SandBoxScene()
    {
        SceneManager.LoadScene("SandBoxScene");
    }

}
