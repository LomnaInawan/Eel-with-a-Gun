using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redSquid : MonoBehaviour
{
    public float scrollSpeed;
    public float destroyIn;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyIn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eel p = collision.GetComponent<eel>();
            p.UpdateLives(-1);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(this.transform.position.x + scrollSpeed, this.transform.position.y + scrollSpeed);
    }
}
