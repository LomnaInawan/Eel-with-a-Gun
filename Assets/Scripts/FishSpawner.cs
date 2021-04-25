using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Color[] colours;
    public float timeBetweenSpawn;

    public GameObject fishPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawner");
    }

    IEnumerator spawner()
    {
        while (true)
        {
            int randomA = Random.Range(0, 6);
            int randomB = Random.Range(0, 6);
            if(randomA >=0 && randomA <= 2)
            {
                Instantiate(fishPrefab, spawnPoints[randomA].position, Quaternion.identity).GetComponent<SpriteRenderer>().color = colours[randomB];
            }
            else
            { 
                GameObject fish = Instantiate(fishPrefab, spawnPoints[randomA].position, Quaternion.identity);
                fish.GetComponent<SpriteRenderer>().color = colours[randomB];
                fish.GetComponent<SpriteRenderer>().flipX = true;
                fish.GetComponent<FishBG>().movingSpeed = new Vector2(-0.01f, 0.01f);
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }

}
