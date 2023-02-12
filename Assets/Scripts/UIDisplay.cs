using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")] 
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Health playerHealth;

    [Header("Score")] [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }


    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
