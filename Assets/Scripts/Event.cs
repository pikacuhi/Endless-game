using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Event : MonoBehaviour
{
    public void ReplayGame(){
        SceneManager.LoadScene("Level");
    }

    public void QuitGame(){
        Application.Quit();
    }


}
