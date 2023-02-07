using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private bool wasCollected;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !wasCollected)
        {
            FindObjectOfType<GameSession>().AddScore(100);
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
            wasCollected = true;
            Destroy(gameObject);
        }
    }
}
