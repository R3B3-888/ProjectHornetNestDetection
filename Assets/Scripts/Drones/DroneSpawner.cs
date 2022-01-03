using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject drone;
    // TODO Serialize Drone
    void Start()
    {
        Vector3 plateformOrigin = transform.position;
        Vector3 platerformBounds = new Vector3(DataBase.Settings.XSize, 0, 2);
        for (var i = 0; i < DataBase.Settings.NbDronesToSpawn; i++)
        {
            GameObject d = Instantiate(drone);
            d.transform.position = new Vector3(platerformBounds.x * i / DataBase.Settings.NbDronesToSpawn, 0, -2);
        }
    }
}
