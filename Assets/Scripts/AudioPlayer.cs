using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")] [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] private float shootingVolume = 1f;
    
    [Header("Damage")] [SerializeField] private AudioClip damageClip;
    [SerializeField] [Range(0f,1f)] private float damageVolume = 1f;

    static AudioPlayer istance;
    
    private void Awake()
    {
        ManageSingleton();
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

    public void PlayShootingClip()
    {
       PlayClip(shootingClip, shootingVolume);
    }
    
    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip!=null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
