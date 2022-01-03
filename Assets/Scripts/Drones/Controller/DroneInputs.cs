using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Drones
{
    [RequireComponent(typeof(PlayerInput))]
    public class DroneInputs : MonoBehaviour
    {
        #region Variables
        private Vector2 cyclic;
        private float pedals;
        private float throttle;

        public Vector2 Cyclic { get => cyclic; set => cyclic = value; }
        public float Pedals { get => pedals; set => pedals = value; }
        public float Throttle { get => throttle; set => throttle = value; }
        #endregion

        #region Main Methods
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Input Methods
        private void OnCyclic(InputValue v)
        {
            cyclic = v.Get<Vector2>();
        }
        private void OnPedals(InputValue v)
        {
            pedals = v.Get<float>();
        }
        private void OnThrottle(InputValue v)
        {
            throttle = v.Get<float>();
        }
        #endregion
    }
}