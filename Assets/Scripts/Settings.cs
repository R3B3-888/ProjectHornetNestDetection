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
        private static int xSize = 100;
        private static int zSize = 100;
        private static int nbDronesToSpawn = 10;
        private static float maxHeight;
        private static Vector3 nestPosition;
        private static bool interactiveMode = false;
        #endregion

        #region Getter Setter
        public static bool GameNestDiscovered { get => gameNestDiscovered; set => gameNestDiscovered = value; }
        public static bool GamePause { get => gamePause; set => gamePause = value; }
        public static int XSize { get => xSize; set => xSize = value; }
        public static int ZSize { get => zSize; set => zSize = value; }
        public static float MaxHeight { get => maxHeight; set => maxHeight = value; }
        public static Vector3 NestPosition { get => nestPosition; set => nestPosition = value; }
        public static bool InteractiveMode { get => interactiveMode; set => interactiveMode = value; }
        public static int NbDronesToSpawn { get => nbDronesToSpawn; set => nbDronesToSpawn = value; }


        #endregion

        #region Main Methods
        void Awake()
        {
            // gameBeginning = true;
            gameNestDiscovered = false;
            gamePause = false;
        }
        private void Update()
        {

        }
        #endregion

        #region Custom Methods

        #endregion
    }
}
