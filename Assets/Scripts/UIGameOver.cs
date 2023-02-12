using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    void Start()
    {
        scoreText.text = "You Scored:\n"+FindObjectOfType<ScoreKeeper>().GetScore();
    }

}
