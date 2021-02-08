using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("NewGame");
        //FindObjectOfType<AudioManager>().Play("Beginning");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}