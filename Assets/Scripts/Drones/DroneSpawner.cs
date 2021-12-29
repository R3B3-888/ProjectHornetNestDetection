using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject drone;
    [Range(1, 50)]
    public int nbToSpawn;
    // TODO Serialize Drone Object with coord et position pour les 
    void Start()
    {
        Vector3 plateformOrigin = transform.position;
        Vector3 platerformBounds = new Vector3(100,0,2);//platerformPlane.GetComponent<MeshRenderer>().bounds.size;
        for (var i = 0; i < nbToSpawn; i++)
        {
            GameObject d = Instantiate(drone);
            d.transform.position = new Vector3(platerformBounds.x * i/nbToSpawn, 0, -2);
        }
    }
}
