using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drones
{
    [RequireComponent(typeof(BoxCollider))]
    public class DroneEngine : MonoBehaviour, IEngine
    {
        #region Variables
        [Header("Engine Properties")]
        [SerializeField] private float maxPower = 4f;
        [Header("Propeller Properties")]
        [SerializeField] private Transform propeller;
        [SerializeField] private float baseRotationSpeed = 50f;
        private Vector3 engineForce;

        #endregion

        #region Interface Methods
        public void InitEngine()
        {
            engineForce = Vector3.zero;
            throw new System.NotImplementedException();
        }

        public void UpdateEngine(Rigidbody rb, DroneInputs input)
        {
            Vector3 upVec = transform.up;
            upVec.x = 0f;
            upVec.z = 0f;
            float diff = 1 - upVec.magnitude;
            float finalDiff = Physics.gravity.magnitude * diff;
            engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude + finalDiff) + (input.Throttle * maxPower)) / 4f;
            rb.AddForce(engineForce, ForceMode.Force);
            HandlePropeller();
        }

        void HandlePropeller()
        {
            if (!propeller)
                return;
            float rotationSpeed = baseRotationSpeed * (this.engineForce.x + this.engineForce.y + this.engineForce.z);
            propeller.Rotate(Vector3.up, rotationSpeed);
        }
        #endregion
    }
}

