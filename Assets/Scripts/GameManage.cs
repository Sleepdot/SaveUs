using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject resultUI;
    public GameObject gameoverUI;
    public GameObject timeoverUI;

    public void CompleteLevel()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            resultUI.SetActive(true);
            Time.timeScale = 0f;
            FindObjectOfType<AudioManager>().Play("Congrat");
            
        }
    }

    public void FailLevel()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            gameoverUI.SetActive(true);
            Time.timeScale = 0f;
            FindObjectOfType<AudioManager>().Play("GameOver");
            
        }
    }

    public void TimeOut()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            timeoverUI.SetActive(true);
            Time.timeScale = 0f;
            FindObjectOfType<AudioManager>().Play("GameOver");
        }
    }

}
