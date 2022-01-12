using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drones
{
    public class DroneKiller : PathController
    {
        #region Variables
        [SerializeField] private float delay = 4f;
        private float countdown;
        private bool hasExploded = false;
        [SerializeField] private GameObject explosionEffect;
        private GameObject explosionObject;
        private bool nestPosAlreadySet;
        #endregion

        #region Main Methods
        private void Start()
        {
            countdown = delay;
        }
        void Update()
        {
            if (!DataBase.Settings.GameNestDiscovered)
                return;
            if (beginning)
                goUpBeginning(DataBase.Settings.MaxHeight);
            else if (goingIn)
            {
                Vector3 posWanted = new Vector3(DataBase.Settings.NestPosition.x, DataBase.Settings.MaxHeight, DataBase.Settings.NestPosition.z);
                goTo(posWanted);
            }
            else if (turningAroundR) // use of this var for the falling 
            {
                if (!hasExploded)
                    goToY(DataBase.Settings.NestPosition.y);
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

