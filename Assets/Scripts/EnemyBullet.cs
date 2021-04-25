using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float DestroIn;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroIn);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eel p = collision.GetComponent<eel>();
            p.UpdateLives(-1);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
}
