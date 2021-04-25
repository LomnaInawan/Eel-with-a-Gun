using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSquid : MonoBehaviour
{
    public float timeperiod = 1;
    public float velocity = 3;
    public float movementVelocity = 3f;
    public float destroIn;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroIn);
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine("Movement");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eel p = collision.GetComponent<eel>();
            p.UpdateLives(-1);
        }
    }

    IEnumerator Movement()
    {
        while (true)
        {
            rb.velocity = (new Vector2(-1, 1)) * velocity + (new Vector2(1,1)) * movementVelocity;
            yield return new WaitForSeconds(timeperiod);

            rb.velocity = (new Vector2(-1, 1)) * velocity * -1 + (new Vector2(1, 1)) * movementVelocity;
            yield return new WaitForSeconds(timeperiod);
        }
    }
    
}
