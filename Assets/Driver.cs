using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    private float steerSpeed;
    
    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private float slowSpeed;
    
    [SerializeField]
    private float boostSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal");
        float moveAmount = Input.GetAxis("Vertical");
        transform.Rotate(0,0,-steerAmount * steerSpeed * Time.deltaTime);
        transform.Translate(0,moveAmount * moveSpeed * Time.deltaTime,0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collisionEnter");
        moveSpeed = 10f;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            moveSpeed = boostSpeed;
        }
        
        if (other.CompareTag("SlowDebuff"))
        {
            moveSpeed = slowSpeed;
        }
    }
}
