using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damagePerBullet;
    public float bulletSpeed;
    public GameObject bulletExplosion;
    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.transform.parent.gameObject);
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(bulletExplosion, this.transform.position, Quaternion.Euler(0,0,Random.Range(0f,360f)));
            Enemy enemyScript;
            enemyScript = collision.GetComponent<Enemy>();
            enemyScript.reduceHealth(damagePerBullet);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector2(transform.position.x - bulletSpeed, transform.position.y - bulletSpeed);
    }
}
