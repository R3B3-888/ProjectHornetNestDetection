using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject drone;
    [Range(1, 20)]
    public int nbToSpawn;
    // TODO Serialize Drone Object with coord et position pour les 
    void Start()
    {
        GameObject platerform = GameObject.Find("DroneSpawner");
        GameObject platerformPlane = GameObject.Find("Plateform");
        Vector3 platerformBounds = platerformPlane.GetComponent<MeshRenderer>().bounds.size;
        for (var i = 0; i < nbToSpawn; i++)
        {
            GameObject d = Instantiate(drone);
            d.transform.position = platerform.transform.position + new Vector3(platerformBounds.x * i/nbToSpawn, 0, platerformBounds.z/2);
        }
    }
}
