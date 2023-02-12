using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    float sceneLoadDelay = 1f;
    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
        
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(String scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
