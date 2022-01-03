using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drones
{
    [RequireComponent(typeof(Rigidbody))]
    public class BaseRigibody : MonoBehaviour
    {
        #region Variables
        [Header("Rigidbody Properties")]
        [SerializeField] private float weight = 0.454f;
        private Rigidbody rb;
        protected float startDrag;
        protected float startAngularDrag;

        public Rigidbody Rb { get => rb; set => rb = value; }
        #endregion

        #region Main Methods
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (rb)
            {
                rb.mass = weight;
                startDrag = rb.drag;
                startAngularDrag = rb.angularDrag;
            }
        }
        private void FixedUpdate()
        {
            if (!rb)
                return;
            HandlePhysics();
        }
        #endregion

        #region Custom Methods
        protected virtual void HandlePhysics()
        {

        }
        #endregion
    }
}

