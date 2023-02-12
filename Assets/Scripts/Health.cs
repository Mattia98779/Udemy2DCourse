using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private int health = 50;
    [SerializeField] private int score = 50;
    [SerializeField] private ParticleSystem hitEffect;

    [SerializeField] private bool applyCameraShake;
    private CameraShake cameraShake;

    private AudioPlayer audioPlayer;
    private ScoreKeeper scoreKeeper;
    private LevelManager levelManager;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        DamageDealer damageDealer = col.GetComponent<DamageDealer>();
        if (damageDealer!=null)
        {
            audioPlayer.PlayDamageClip();
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void ShakeCamera()
    {
        if (cameraShake!=null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health<=0)
        {
            Die();
            
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (hitEffect!=null)
        {
            ParticleSystem istance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(istance.gameObject, istance.main.duration + istance.main.startLifetime.constantMax);
        }
    }
}
