using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Transform gunpoint1;
    public Transform gunpoint2;
    public Transform laserPoint;
    public float shootingRate;
    public GameObject bulletPrefab;
    public GameObject laserPrefab;
    public float laserSpeed;
    public float bulletSpeed;
    public float velocity;
    public float DestroyIn;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyIn);
        StartCoroutine("Shooting");
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            Rigidbody2D rb1 = Instantiate(bulletPrefab, gunpoint1.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = Instantiate(bulletPrefab, gunpoint2.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            Rigidbody2D rb3 = Instantiate(laserPrefab, laserPoint.position, Quaternion.Euler(0,0,45)).GetComponent<Rigidbody2D>();
            this.GetComponent<AudioSource>().Play();
            rb1.velocity = new Vector2(1, 1) * bulletSpeed;
            rb2.velocity = new Vector2(1, 1) * bulletSpeed;
            rb3.velocity = new Vector2(1, 1) * laserSpeed;
            yield return new WaitForSeconds(shootingRate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<eel>().UpdateLives(-1);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector2(transform.position.x + velocity, transform.position.y + velocity);
    }
}
