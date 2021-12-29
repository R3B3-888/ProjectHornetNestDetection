using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drones
{
    public class DronePatrol : PathController
    {
        #region Variables
        private float mapEdgeZ;
        private bool newPosAlreadySet;
        private bool[] steps;
        #endregion

        #region Main Methods
        private void Start() {
            newPosAlreadySet = false;
            steps = new bool[] {beginning, goingIn, turningAroundR, goingBack, turningAroundL};
        }
        void Update()
        {
            mapEdgeZ = MapGenerator.zSize + 2f;
            if (steps[0]) // raise up
            {
                goUpBeginning(20f);
                steps[0] = beginning;
                steps[1] = goingIn;
            } 
            else if (steps[1]) // first going
            {
                if(!newPosAlreadySet)
                {
                    // TODO : offset banc décollage
                    positionWanted = drone.transform.position;
                    positionWanted.z += mapEdgeZ;
                    newPosAlreadySet = true;
                }
                goTo(positionWanted);
                adjustHeight();
                // isNotHighEnough();
                steps[1] = goingIn;
                steps[2] = turningAroundR;
            } 
            else if (steps[2]) // turn around at the forest's edge
            {
                turnAroundR(180);
                steps[2] = turningAroundR;
                steps[3] = goingBack;
                newPosAlreadySet = false;
            } 
            else if (steps[3]) // going back
            {
                if (!newPosAlreadySet)
                {
                    positionWanted = drone.transform.position;
                    positionWanted.z -= mapEdgeZ;
                    newPosAlreadySet = true;
                }
                goTo(positionWanted);
                adjustHeight();
                // isNotHighEnough();
                steps[3] = goingBack;
                steps[4] = turningAroundL;
            }
            else if (steps[4]) // turn around for set up a new trip
            {
                turnAroundL(0);
                steps[4] = turningAroundL;
                steps[1] = goingIn;
                newPosAlreadySet = false;
            }
        }
        #endregion
    }
}
