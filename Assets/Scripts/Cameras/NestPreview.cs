using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cameras
{
    public class NestPreview : MonoBehaviour
    {
        Transform nestTransform;
        void Awake()
        {
            nestTransform = MapGenerator.NestObject.transform;
            Debug.Log(nestTransform.position);
        }
    }
}
