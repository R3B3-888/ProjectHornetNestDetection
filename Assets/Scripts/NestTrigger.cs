using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class NestTrigger : MonoBehaviour
    {
        #region Variables
        
        #endregion

        #region Main Methods
        private void OnTriggerEnter(Collider other) {
            Debug.Log("Nest triggered");
        }

        private void OnTriggerExit(Collider other) {
            Debug.Log("Nest triggered exited");
        }
        #endregion

    }
}
