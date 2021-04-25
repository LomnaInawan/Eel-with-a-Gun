using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamemanager : MonoBehaviour
{

    public GameObject startMenu;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1;
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
