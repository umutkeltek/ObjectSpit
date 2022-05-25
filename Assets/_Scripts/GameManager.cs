using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public int totalGold;
    private int currentScene;
    
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 0.9f;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }
}