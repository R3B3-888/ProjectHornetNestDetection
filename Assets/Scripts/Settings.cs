using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBase
{
    public class Settings : MonoBehaviour
    {
        #region Variables
        // private static bool gameBeginning;
        private static bool gameNestDiscovered;
        private static bool gamePause;
        private static int xSize;
        private static float maxHeight;
        private static Vector3 nestPosition;
        #endregion

        #region Getter Setter
        public static bool GameNestDiscovered { get => gameNestDiscovered; set => gameNestDiscovered = value; }
        public static bool GamePause { get => gamePause; set => gamePause = value; }
        public static int XSize { get => xSize; set => xSize = value; }
        public static float MaxHeight { get => maxHeight; set => maxHeight = value; }
        public static Vector3 NestPosition { get => nestPosition; set => nestPosition = value; }

        #endregion

        #region Main Methods
        void Start()
        {
            // gameBeginning = true;
            gameNestDiscovered = false;
            gamePause = false;
            xSize = 100;
        }
        private void Update()
        {

        }
        #endregion

        #region Custom Methods

        #endregion
    }
}
