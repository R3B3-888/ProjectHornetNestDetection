using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drones
{
    public class DroneKiller : PathController
    {
        #region Variables
        private Vector3 nestPosition;
        [SerializeField] private float delay = 3f;
        private float countdown;
        private bool hasExploded = false;
        [SerializeField] private GameObject explosionEffect;
        private GameObject explosionObject;
        #endregion

        #region Main Methods
             
        private void Start() {
            countdown = delay;
        }
        void Update()
        {
            
            if(beginning)
                goUpBeginning(20f);
            else if (goingIn)
            {
                nestPosition = MapGenerator.TreeWithNest.Nest.transform.position;
                goTo(new Vector3(nestPosition.x, 20f, nestPosition.z));
            } else if (turningAroundR) // use of this var for the falling 
            {
                if (!hasExploded)
                    goToY(nestPosition.y);
                countdown -= Time.deltaTime;
                if (countdown <= 0f && !hasExploded)
                {
                    Explode();
                    hasExploded = true;
                }
                else if (countdown <= -1.5f && hasExploded)
                {
                    GameObject.Destroy(explosionObject);
                    GameObject.DestroyImmediate(explosionObject);
                }
            }
        }
        #endregion

        private void Explode()
        {
            explosionObject = Instantiate(explosionEffect, drone.transform.position, drone.transform.rotation);
            Destroy(MapGenerator.NestObject);
            Destroy(this.drone);
        }
    }
}

