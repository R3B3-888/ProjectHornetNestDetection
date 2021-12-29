using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject drone;
    // TODO Serialize Drone Object with coord et position pour les 
    void Start()
    {
        GameObject platerform = GameObject.Find("DroneSpawner");
        GameObject platerformPlane = GameObject.Find("Plateform");
        GameObject d = Instantiate(drone);
        Vector3 platerformBounds = platerformPlane.GetComponent<MeshRenderer>().bounds.size;
        d.transform.position = platerform.transform.position + new Vector3(platerformBounds.x/2, 0, platerformBounds.z/2);
    }
}
