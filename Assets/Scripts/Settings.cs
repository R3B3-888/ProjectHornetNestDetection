using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBase
{
    public class Settings : MonoBehaviour
    {
        #region Variables
        // private static bool gameBeginning;
        private static bool gameNestDiscovered, gamePause, interactiveMode = false;
        private static int xSize = 100, zSize = 100, spaceBetweenTrees = 4, nbDronesToSpawn = 10, meshSeed = 63;
        private static float maxHeight, lacunarity = 2f, scale = 50f;
        private static Vector3 nestPosition;
        public enum UISettingsInt { ZSize, XSize, SpaceBetweenTrees, NbDronesToSpawn, MeshSeed }
        public enum UISettingsFloat { Lacunarity, Scale }
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
        public static int SpaceBetweenTrees { get => spaceBetweenTrees; set => spaceBetweenTrees = value; }
        public static float Lacunarity { get => lacunarity; set => lacunarity = value; }
        public static int MeshSeed { get => meshSeed; set => meshSeed = value; }
        public static float Scale { get => scale; set => scale = value; }

        public static int GetValue(UISettingsInt settings)
        {
            switch (settings)
            {
                case UISettingsInt.XSize:
                    return XSize;
                case UISettingsInt.ZSize:
                    return ZSize;
                case UISettingsInt.SpaceBetweenTrees:
                    return SpaceBetweenTrees;
                case UISettingsInt.NbDronesToSpawn:
                    return NbDronesToSpawn;
                case UISettingsInt.MeshSeed:
                    return MeshSeed;
                default:
                    return 0;
            }
        }
        public static float GetValue(UISettingsFloat setting)
        {
            switch (setting)
            {
                case UISettingsFloat.Lacunarity:
                    return Lacunarity;
                case UISettingsFloat.Scale:
                    return Scale;
                default:
                    return 0f;
            }
        }
        public static void SetValue(UISettingsInt setting, int v)
        {
            switch (setting)
            {
                case UISettingsInt.XSize:
                    xSize = v;
                    break;
                case UISettingsInt.ZSize:
                    zSize = v;
                    break;
                case UISettingsInt.SpaceBetweenTrees:
                    spaceBetweenTrees = v;
                    break;
                case UISettingsInt.NbDronesToSpawn:
                    nbDronesToSpawn = v;
                    break;
                case UISettingsInt.MeshSeed:
                    meshSeed = v;
                    break;
                default:
                    break;
            }
        }
        public static void SetValue(UISettingsFloat setting, float v)
        {
            switch (setting)
            {
                case UISettingsFloat.Lacunarity:
                    Lacunarity = v;
                    break;
                case UISettingsFloat.Scale:
                    Scale = v;
                    break;
                default:
                    break;
            }
        }

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
