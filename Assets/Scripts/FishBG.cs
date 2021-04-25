using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBG : MonoBehaviour
{
    public Vector2 movingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector2(transform.position.x+ movingSpeed.x, transform.position.y + movingSpeed.y);
        if (transform.position.y >= 6)
        {
            Destroy(gameObject);
        }
    }
}
