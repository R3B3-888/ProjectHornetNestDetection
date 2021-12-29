using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static bool IsInitialised { get; private set; }
    public static GameObject mainMenu;
    public static GameObject pauseMenu, settingsMenu;

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        // mainMenu = canvas.transform.Find("MainMenu").gameObject;
        pauseMenu = canvas.transform.Find("PauseMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;
        IsInitialised = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitialised) Init();
        switch (menu)
        {
            case Menu.MAIN_MENU:
                SceneManager.LoadScene("MenuScene");
                // mainMenu.SetActive(true);
                break;
            case Menu.SETTINGS:
                settingsMenu.SetActive(true);
                break;
            case Menu.PAUSE:
                pauseMenu.SetActive(true);
                break;
        }
        callingMenu.SetActive(false);
    }
}
