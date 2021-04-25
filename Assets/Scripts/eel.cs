using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class eel : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 input;
    Vector2 raw;
    Animator anim;
    bool invincible = false;

    public TMP_Text livesText;
    public TMP_Text scoreText;
    public float velocity;
    public float Lives = 3;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        input[0] = Input.GetAxis("Horizontal");
        input[1] = Input.GetAxis("Vertical");
        raw[0] = Input.GetAxisRaw("Horizontal");
        raw[1] = Input.GetAxisRaw("Vertical");
    }

    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score.ToString();
    }

    public void UpdateLives(int change)
    {
        if (invincible == false)
        {
            Lives += change;
            livesText.text = "Lives : " + Lives.ToString();
            if (Lives <= 0)
            {
                Debug.Log("Game End");
            }
            StartCoroutine("flashSprite");
        }
    }

    IEnumerator flashSprite()
    {
        invincible = true;
        this.GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i <= 3; i++)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            this.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        invincible = false;
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (raw[0] != 0 && raw[1] == 0)
        {
            //move in x axis
            Vector2 v = new Vector2(-1, -1);
            Vector2 velocityX = v * input[0] * velocity * -1;
            rb.velocity = velocityX;
            if (velocityX[0] < 0)
            {
                anim.speed = 2;
            }else if(velocityX[0] > 0)
            {
                anim.speed = 0.5f;
            }

        }
        else if (raw[1] != 0 && raw[0] == 0)
        {
            //move in y axis
            Vector2 v = new Vector2(-1, 1);
            rb.velocity = v * input[1] * velocity;
            anim.speed = 1;
        } 
        else if (raw == new Vector2(0, 0))
        {
            anim.speed = 1;
        }
    }
}
