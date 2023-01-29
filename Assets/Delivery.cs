using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private bool hasPackege;

    [SerializeField] private float destroyDelay;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Package") && !hasPackege)
        {
            Debug.Log("Package picked up");
            spriteRenderer.color = hasPackageColor;
            Destroy(col.gameObject,destroyDelay);
            hasPackege = true;
        }
        
        if (col.CompareTag("Customer") && hasPackege)
        {
            Debug.Log("Customer reached and package delivered");
            spriteRenderer.color = noPackageColor;
            Destroy(col.gameObject,destroyDelay);
            hasPackege = false;
            
        }
    }
}
