using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifeTime = 5f;
    [SerializeField] private float baseFireRate = 0.2f;
    
    [Header("AI")]
    [SerializeField] private float fireRateVariace = 0f;
    [SerializeField] private float minFireRate = 0.1f;
    [SerializeField] private bool useAI;
    
    [HideInInspector] public bool isFiring;

    private Coroutine firingCoroutine;

    private AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if (!isFiring && firingCoroutine!=null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }

    IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject istance = Instantiate(projectilePrefab, transform.position, quaternion.identity);
            Rigidbody2D rb = istance.GetComponent<Rigidbody2D>();
            if (rb!=null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(istance, projectileLifeTime);
            float timeToNext = Random.Range(baseFireRate - fireRateVariace, baseFireRate + fireRateVariace);
            timeToNext = Mathf.Clamp(timeToNext, minFireRate, float.MaxValue);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(timeToNext);
        }
    }
}
