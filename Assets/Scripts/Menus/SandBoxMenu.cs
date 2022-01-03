using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class SandBoxMenu : MonoBehaviour
    {
        #region Variables
        private static GameObject sandBoxMenu;
        #endregion

        #region Main Methods
        void Start()
        {
            GameObject canvas = GameObject.Find("Canvas");
            sandBoxMenu = canvas.transform.Find("SandBoxMenu").gameObject;
        }

        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (DataBase.Settings.GamePause)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
                Debug.Log("Pause ?");
            }
        }
        #endregion

        #region Custom Methods
        public void Resume()
        {
            DataBase.Settings.GamePause = false;
            Time.timeScale = 1f;
            sandBoxMenu.SetActive(false);
        }

        public void Pause()
        {
            DataBase.Settings.GamePause = true;
            Time.timeScale = 0f; // freeze time
            sandBoxMenu.SetActive(true);
        }

        public void OnClick_LoadMenu()
        {
            Time.timeScale = 1f;
            DataBase.Settings.GamePause = false;
            SceneManager.LoadScene("MenuScene");
        }
        #endregion
    }
}
