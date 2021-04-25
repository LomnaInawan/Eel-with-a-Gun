using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackingGun : MonoBehaviour
{
    float angle;
    Vector2 direction;
    Transform player;
    // Start is called before the first frame update

    public float DestroIn;
    public Transform gun;
    public GameObject prefabBullet;
    public float timeBetweenShots;
    public Transform gunpoint;
    public float gunSpeed;

    void Start()
    {
        StartCoroutine("attack");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    IEnumerator attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShots);
            Instantiate(prefabBullet, transform.position, Quaternion.Euler(0,0,angle)).GetComponent<Rigidbody2D>().velocity = (direction / direction.magnitude) * gunSpeed; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<eel>().UpdateLives(-1);
        }
    }

    private void Update()
    {
        if(transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = new Vector2(player.position.x - this.transform.position.x, player.position.y - this.transform.position.y);
        if(direction.x == 0 && direction.y > 0)
        {
            angle = 0;
        }else if(direction.x == 0 && direction.y < 0)
        {
            angle = 180;
        }
        else
        {
            Vector2 x = new Vector2(1, 0);
            float c = Mathf.Acos(direction.x / direction.magnitude);
            float t = Mathf.Atan(direction.y / direction.x);
            if(direction.y > 0)
            {
                angle = c * 57.2957795131f;
            }else if(direction.x <0 && direction.y < 0){
                angle = t * 57.2957795131f + 180;
            }
            else if(direction.x > 0 && direction.y < 0)
            {
                angle = t * 57.2957795131f;
            }
        }
        gun.eulerAngles =new Vector3(0, 0, angle);
    }
}
