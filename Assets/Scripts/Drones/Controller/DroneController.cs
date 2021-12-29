using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Drones
{
    [RequireComponent(typeof(DroneInputs))]
    public class DroneController : BaseRigibody
    {
        #region Variables
        [Header("Control Properties")]
        [SerializeField] private float minMaxPitch = 30f;
        [SerializeField] private float minMaxRoll = 30f;
        [SerializeField] private float yawPower = 3f;

        [SerializeField] private float lerpSpeed = 2f;

        private DroneInputs input;
        private List<IEngine> engines = new List<IEngine>();

        private static float yaw;
        private float finalPitch;
        private float finalYaw;

        private float finalRoll;

        public DroneInputs Input { get => input; set => input = value; }
        public static float Yaw { get => yaw; set => yaw = value; }

        #endregion

        #region Main Methods
        void Start()
        {
            Input = GetComponent<DroneInputs>();
            engines = GetComponentsInChildren<IEngine>().ToList<IEngine>();
        }
        #endregion
        
        #region Custom Methods
        protected override void HandlePhysics()
        {
            // base.HandlePhysics();
            HandleEngines();
            HandleControls();
        }

        protected virtual void HandleEngines()
        {
            
            foreach (var engine in engines)
                engine.UpdateEngine(Rb, Input);
        }
        protected virtual void HandleControls()
        {
            float pitch = Input.Cyclic.y * minMaxPitch;
            float roll = -Input.Cyclic.x * minMaxRoll;
            yaw += Input.Pedals * yawPower;

            finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
            finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);
            finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
            Quaternion rotation = Quaternion.Euler(finalPitch, finalYaw, finalRoll);
            Rb.MoveRotation(rotation);
            // Clamp for tork
        }

        #endregion
    }
}