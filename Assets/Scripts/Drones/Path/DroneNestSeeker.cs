using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drones
{
    public class DroneNestSeeker : PathController
    {
        void Update()
        {
            if(beginning)
                goUpBeginning(10f);
            else if (!beginning)
            {
                positionWanted = MapGenerator.TreeWithNest.Nest.transform.position;
                goTo(positionWanted);
            }
        }
    }
}

