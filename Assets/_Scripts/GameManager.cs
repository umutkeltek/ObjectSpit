using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public int totalGold;
    public int currentScene;
    
    private static GameManager instance = null;
    void Awake(){
        if(instance == null)
        {
            instance = this;
            currentScene = SceneManager.GetActiveScene().buildIndex;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }
    private void Start()
    {
        
        Time.timeScale = 0.9f;
        DontDestroyOnLoad(this.gameObject);

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