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
        private static int xSize;
        #endregion

        #region Getter Setter
        public static bool GameNestDiscovered { get => gameNestDiscovered; set => gameNestDiscovered = value; }
        public static bool GamePause { get => gamePause; set => gamePause = value; }
        public static int XSize { get => xSize; set => xSize = value; }

        #endregion

        #region Main Methods
        void Start()
        {
            gameBeginning = true;
            gameNestDiscovered = false;
            gamePause = false;
            xSize = 100;
        }
        private void Update()
        {
            if (Time.frameCount > 10)
                gameBeginning = false;
        }
        #endregion

        #region Custom Methods

        #endregion
    }
}
