using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private CapsuleCollider2D myCapsuleCollider;
    private BoxCollider2D myFeetCollider;
    private float gravityScaleAtStart;
    
    [SerializeField]
    private float runSpeed = 5f;
    
    [SerializeField]
    private float jumpSpeed = 5f;
    
    [SerializeField]
    private float climbSpeed = 5f;

    private bool isAlive = true;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gun;


    [SerializeField] private Vector2 deathKick = new Vector2(10f,10f);
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isAlive)
        {
            Run();
            FlipSprite();
            ClimbLadder();
            Die();
        }
    }

    private void Die()
    {
        if (myRigidbody.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidbody.velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }

    private void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("isClimbing", false);
            myRigidbody.gravityScale = gravityScaleAtStart;
            return;
        }
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed );
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;
        bool hasPlayerVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", hasPlayerVerticalSpeed);
    }

    private void FlipSprite()
    {
        bool hasPlayerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (hasPlayerHorizontalSpeed)
        {
            transform.localScale = new Vector3(Mathf.Sign(myRigidbody.velocity.x), 1f, 1f);

        }
    }

    private void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool hasPlayerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", hasPlayerHorizontalSpeed);
    }

    void OnMove(InputValue value)
    {
        if (isAlive)
        {
            moveInput = value.Get<Vector2>();
            Debug.Log(moveInput);
        }
        
    }

    void OnJump(InputValue value)
    {
        if (isAlive)
        {
            if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                return;
            }
            if (value.isPressed)
            {
                myRigidbody.velocity += new Vector2(0f, jumpSpeed);
            }
        }
        
    }

    void OnFire(InputValue value)
    {
        Instantiate(bullet, gun.position, transform.rotation);
    }
}
