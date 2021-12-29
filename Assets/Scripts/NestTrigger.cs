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
        private void Start() {
            droneKiller = GameObject.Find("DroneKiller");
            if (droneKiller)
                droneKiller.SetActive(false);
        }
        private void OnTriggerEnter(Collider other) {
            Debug.Log("Nest triggered");
            if (droneKiller)
                droneKiller.SetActive(true);
        }

        private void OnTriggerExit(Collider other) {
            Debug.Log("Nest triggered exited");
        }
        #endregion

    }
}
