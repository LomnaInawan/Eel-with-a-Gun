using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject bulletPrefab;
    public float TimeBetweenShots;
    
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("shooting");
    }

    IEnumerator shooting()
    {
        while (true && this.enabled == true){
            yield return new WaitForSeconds(TimeBetweenShots);
            Instantiate(bulletPrefab, spawnPos.position,Quaternion.identity);
            this.GetComponent<AudioSource>().Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
