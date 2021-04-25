using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject sound;
    public float scrollSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eel p = collision.GetComponent<eel>();
            p.UpdateLives(+1);
            Instantiate(sound, this.transform.position.normalized, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(this.transform.position.x + scrollSpeed, this.transform.position.y + scrollSpeed);
    }
}
