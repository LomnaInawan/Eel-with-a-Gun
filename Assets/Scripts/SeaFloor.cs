using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaFloor : MonoBehaviour
{
    public Vector2 EndA;
    public Vector2 EndB;
    Transform floorTiles;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        floorTiles = this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        floorTiles.position = new Vector2(floorTiles.position.x + speed, floorTiles.position.y + speed);
        if (transform.position.x >= EndB.x && transform.position.y >= EndB.y)
        {
            transform.position = EndA;        
        }
    }
}
