using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject dropItem;
    public float dropRate;
    public float health;
    public float scaleOfExplosion;
    public int scoreToKill;

    // Start is called before the first frame update
    public void reduceHealth(float reduce)
    {
        health -= reduce;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            if(Random.Range(0f,1f) <= dropRate)
            {
                Instantiate(dropItem, this.transform.position, Quaternion.identity);
            }
            Instantiate(explosionPrefab, this.transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f))).transform.localScale = new Vector3(scaleOfExplosion,scaleOfExplosion,1f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<eel>().updateScore(scoreToKill);
            Destroy(gameObject);
        }
    }
}
