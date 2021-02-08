using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject resultUI;
    public GameObject gameoverUIlow;
    public GameObject gameoverUIhigh;

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

    public void EndGamelow()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            gameoverUIlow.SetActive(true);
            Time.timeScale = 0f;
            FindObjectOfType<AudioManager>().Play("GameOver");
            
        }
    }

    public void EndGamehigh()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            gameoverUIhigh.SetActive(true);
            Time.timeScale = 0f;
            FindObjectOfType<AudioManager>().Play("GameOver");
            
        }
    }

}
