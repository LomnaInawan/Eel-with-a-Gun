using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject vehiclePrefab;
    public GameObject shipPrefab;

    public Transform[] vehicle;
    public Transform[] ship;

    public float timeIfShipSpawned;
    public float timeIfVehicleSpawned;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawning");
    }

    IEnumerator spawning()
    {
        while (true)
        {
            if(Random.Range(0,4) <= 2)
            {
                Instantiate(vehiclePrefab, vehicle[Random.Range(0,vehicle.Length)].position, Quaternion.Euler(0, 0, -45)); //Spawn a vehicle
                yield return new WaitForSeconds(timeIfVehicleSpawned);
            }
            else
            {
                Instantiate(shipPrefab, ship[Random.Range(0,ship.Length)].position, Quaternion.Euler(0, 0, -45)); //Spawn a ship
                yield return new WaitForSeconds(timeIfShipSpawned);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
