using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBase
{
    public class Settings : MonoBehaviour
    {
        #region Variables
        private static bool gameBeginning;
        private static bool gameNestDiscovered;
        private static bool gamePause;

        public static bool GameNestDiscovered { get => gameNestDiscovered; set => gameNestDiscovered = value; }
        public static bool GamePause { get => gamePause; set => gamePause = value; }

        #endregion

        #region Main Methods
        void Start()
        {
            gameBeginning = true;
            gameNestDiscovered = false;
            gamePause = false;
        }
        private void Update() {
            if (Time.frameCount > 10)
                gameBeginning = false;
        }
        #endregion

        #region Custom Methods
        
        #endregion
    }
}
