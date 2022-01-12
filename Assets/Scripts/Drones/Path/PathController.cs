using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drones
{
    public class PathController : MonoBehaviour
    {
        #region Variables
        [SerializeField] protected GameObject drone;
        protected DroneController droneController;
        protected bool beginning;
        protected bool turningAroundR;
        protected bool turningAroundL;
        protected bool goingIn;
        protected bool goingBack;
        // protected Queue steps;
        protected Vector3 positionWanted;
        [Range(10, 20)]
        [SerializeField] private int distanceMinDroneAndTrees = 10;
        #endregion

        #region Main Methods
        void Awake()
        {
            droneController = drone.GetComponent<DroneController>();
            beginning = true;
            turningAroundR = false;
            turningAroundL = false;
            goingIn = false;
            goingBack = false;
        }
        #endregion

        #region Stop Methods
        protected void stopTurning()
        {
            droneController.Input.Pedals = 0;
        }
        #endregion

        #region Yaw Methods
        protected void turnAroundR(int degree)
        {
            stopTurning();
            if (droneController.Yaw == degree)
                Invoke("activateGoingBack", 2.5f);
            else if (droneController.Yaw < degree)
                turnRight();
        }

        protected void turnRight()
        {
            droneController.Input.Pedals = 1;
        }

        protected void turnAroundL(int degree)
        {
            stopTurning();
            if (droneController.Yaw == degree)
                Invoke("activateGoingIn", 2.5f);
            else if (droneController.Yaw > (-1 * degree))
                turnLeft();
        }

        protected void turnLeft()
        {
            droneController.Input.Pedals = -1;
        }
        #endregion

        #region GoTo Methods
        protected void goUpBeginning(float yBeginning)
        {
            goToY(yBeginning);
            if (drone.transform.position.y > (yBeginning - 0.25) &&
                drone.transform.position.y < (yBeginning + 0.25))
            {
                beginning = false;
                goingIn = true;
            }
        }

        protected void goTo(Vector3 posWanted)
        {
            goToX(posWanted.x);
            goToY(posWanted.y);
            goToZ(posWanted.z);
            if (isPositionReached(posWanted))
            {
                goingIn = false;
                turningAroundR = true;
                goingBack = false;
                turningAroundL = true;
            }

        }

        protected void goToX(float xWanted)
        {
            if (droneController.Input == null)
                return;
            float x = drone.transform.position.x;
            float yCyclic = droneController.Input.Cyclic.y;
            if (x < xWanted - 0.5f)
                droneController.Input.Cyclic = new Vector2(1f, yCyclic);
            else if (x > xWanted + 0.5f)
                droneController.Input.Cyclic = new Vector2(-1f, yCyclic);
            else
                droneController.Input.Cyclic = new Vector2(0, yCyclic);
        }

        protected void goToY(float yWanted)
        {
            if (droneController.Input == null)
                return;
            float y = drone.transform.position.y;
            if (y < yWanted - 0.25f)
                droneController.Input.Throttle = 1;
            else if (y > yWanted + 0.25f)
                droneController.Input.Throttle = -1;
            else
                droneController.Input.Throttle = 0;
        }

        protected void goToZ(float zWanted)
        {
            if (droneController.Input == null)
                return;
            var neg = goingBack ? -1 : 1;
            float z = drone.transform.position.z;
            float xCyclic = droneController.Input.Cyclic.x;
            if (z < zWanted - 0.5f)
                droneController.Input.Cyclic = new Vector2(xCyclic, neg * 1f);
            else if (z > zWanted + 0.5f)
                droneController.Input.Cyclic = new Vector2(xCyclic, neg * -1f);
            else
                droneController.Input.Cyclic = new Vector2(xCyclic, 0);
        }

        protected void goToOptimized(Vector3 posWanted)
        {
            Vector3 droneCurrentPos = drone.transform.position;
            Debug.Log(droneCurrentPos);
        }
        #endregion

        #region Check Methods
        protected bool isPositionReached(Vector3 posWanted)
        {
            float x = drone.transform.position.x;
            float y = drone.transform.position.y;
            float z = drone.transform.position.z;
            if ((y < posWanted.y - 0.25f) || (y > posWanted.y + 0.25f) ||
                (z < posWanted.z - 0.5f) || (z > posWanted.z + 0.5f) ||
                (x < posWanted.x - 0.5f) || (x > posWanted.x + 0.5f))
                return false;
            return true;
        }

        protected void adjustHeight()
        {
            if (isNotHighEnough())
                droneController.Input.Throttle = 1;
        }

        protected bool isNotHighEnough()
        {
            RaycastHit hit;
            Vector3 direction = drone.transform.TransformDirection(Vector3.down);
            direction.z *= -1;
            Debug.DrawRay(drone.transform.position, direction * distanceMinDroneAndTrees, Color.red);
            // Vector3 detection = drone.transform.TransformDirection(Vector3.forward);
            // Debug.DrawRay(drone.transform.position, detection * distanceMinDroneAndTrees * 2, Color.cyan);
            return Physics.Raycast(drone.transform.position, direction, out hit, distanceMinDroneAndTrees);
        }
        #endregion

        private void activateGoingBack()
        {
            turningAroundR = false;
            goingBack = true;
        }

        private void activateGoingIn()
        {
            turningAroundL = false;
            goingIn = true;
        }
    }
}
