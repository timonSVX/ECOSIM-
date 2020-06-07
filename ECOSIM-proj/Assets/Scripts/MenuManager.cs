using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public void pressPlay()
    {
        SceneManager.LoadScene("Game");
        isGamePaused = false;
        Time.timeScale = 1f;
    }

    public void pressQuit()
    {
        Application.Quit();
    }

    public void pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);  
        isGamePaused = true;
    }

    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isGamePaused = false;
    }

    public void pressMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // a l'appui sur Echap
        {
            if(isGamePaused)
            {
                resume(); 
            }
            else
            { pause(); }
        }
    }



}
