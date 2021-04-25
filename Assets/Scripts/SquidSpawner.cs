using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidSpawner : MonoBehaviour
{
    public GameObject redSquidPrefab;
    public GameObject greenSquidPrefab;
    public float timeBetweenSpawn;

    public Transform[] redSquid;
    public Transform[] greenSquid;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawner");
    }

    IEnumerator spawner()
    {
        while (true)
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                Instantiate(redSquidPrefab, redSquid[Random.Range(0, redSquid.Length)].position, Quaternion.identity);
                Instantiate(redSquidPrefab, redSquid[Random.Range(0, redSquid.Length)].position, Quaternion.identity);
            }
            else
            {
                Instantiate(greenSquidPrefab, greenSquid[Random.Range(0, greenSquid.Length)].position, Quaternion.identity);
                Instantiate(greenSquidPrefab, redSquid[Random.Range(0, redSquid.Length)].position, Quaternion.identity);
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
