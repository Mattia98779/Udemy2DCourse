using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem snowTrail;

    private void OnCollisionEnter2D(Collision2D col)
    {
        snowTrail.Play();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        snowTrail.Stop();
    }
}
