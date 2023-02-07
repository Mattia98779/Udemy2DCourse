using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField]
    float timeToExit = 2f;

    public bool exiting = false;
    
    IEnumerator ExitLevel()
    {
        yield return new WaitForSecondsRealtime(timeToExit);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("index = " + currentSceneIndex);
        if (currentSceneIndex+1 == SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = -1;
        }

        Debug.Log(currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("player exiting");
        if (!exiting && col.CompareTag("Player"))
        {
            StartCoroutine(ExitLevel());
            exiting = true;
        }
        
    }
}
