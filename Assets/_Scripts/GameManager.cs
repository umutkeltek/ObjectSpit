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
        currentScene = SceneManager.GetActiveScene().buildIndex; //�u anki sahneyi al�p next yap�yor
        if (currentScene != SceneManager.sceneCountInBuildSettings-1)
        {
            SceneManager.LoadScene(currentScene + 1);
            AdManager.Instance.showAds();
        }
        else
        {
            SceneManager.LoadScene(0);
            AdManager.Instance.showAds();
        }
        //print(SceneManager.sceneCountInBuildSettings);  //son sahneyi bulmak i�in
    }

    public void RestartLevel()
    {   AdManager.Instance.showAds();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}               