using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 1f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;
    private bool crashed = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") && !crashed)
        {
            crashed = true;
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            FindObjectOfType<PlayerController>().DisableControls();
            Invoke("ReloadScene", reloadDelay);
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
