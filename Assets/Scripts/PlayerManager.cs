using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameoverPanel;
    void Start()
    {
       // default slalu false pstinya
       gameOver = false;
       Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver){
            Time.timeScale = 0;
            gameoverPanel.SetActive(true);
        }
    }
}
