using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private bool canMove = true;

    [SerializeField] private float torgueAmount;
    [SerializeField] private float boostSpeed;
    [SerializeField] private float normalSpeed;

    private SurfaceEffector2D surfaceEffector2D;
    
    // Start is called before the first frame update
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
       surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondeToBoost();
        }
        
    }

    private void RespondeToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
        
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torgueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torgueAmount);
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
}
