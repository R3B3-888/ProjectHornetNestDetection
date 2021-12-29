using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drones
{
    public class DroneStraightLine : PathController
    {
        #region Variables
        [SerializeField] private float yWanted = 10f;
        [SerializeField] private float zWanted = 100f;
        #endregion

        #region Main Methods
        private void Start() {
            positionWanted = new Vector3(transform.position.x, yWanted, zWanted);
        }
        void Update()
        {
            if(beginning)
                goUpBeginning(10f);
            else if (!beginning)
            {
                goTo(positionWanted);
                adjustHeight();
            }
        }
        #endregion
    }
}