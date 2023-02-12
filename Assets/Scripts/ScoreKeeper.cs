using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score;

    private ScoreKeeper istance;

    private void Awake()
    {
        ManageSingleton();
    }

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
    
    private void ManageSingleton()
    {
        if (istance !=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            istance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
