using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamemanager : MonoBehaviour
{

    public float time;
    public GameObject startMenu;
    public GameObject spawner;

    public TMP_Text highScore;

    eel player;

    bool finalStage = false;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<eel>();
        Time.timeScale = 0;
    }

    private void Start()
    {
        highScore.text = "Your HighScore is : " + PlayerPrefs.GetInt("HighScore").ToString();
        StartCoroutine("CountTime");
    }

    IEnumerator CountTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            time += 0.1f;
        }
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        if (player.score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", player.score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }   
    }
}
