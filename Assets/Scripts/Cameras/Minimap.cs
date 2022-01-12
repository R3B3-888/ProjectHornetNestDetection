using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBase;

namespace Cameras
{
    public class Minimap : MonoBehaviour
    {
        void Start()
        {
            transform.position = new Vector3(Settings.XSize/2, 20, Settings.ZSize/2);
            transform.rotation = Quaternion.Euler(90, 0, 0);
            var cam = GetComponent<Camera>();
            cam.orthographic = true;
            cam.orthographicSize = Mathf.Max(Settings.ZSize, Settings.XSize) / 2;
        }
    }
}
