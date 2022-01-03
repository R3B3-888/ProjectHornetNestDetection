using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class NestTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject droneKiller;

        #endregion

        #region Main Methods
        private void Start()
        {
            droneKiller = GameObject.Find("DroneKiller");
            if (droneKiller && !DataBase.Settings.GameNestDiscovered)
                droneKiller.SetActive(false);
        }
        #endregion
        
        #region Trigger Methods
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Nest triggered");
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Nest triggered exited");
            droneKiller.SetActive(true);
            DataBase.Settings.GameNestDiscovered = true;
        }
        #endregion
    }
}
