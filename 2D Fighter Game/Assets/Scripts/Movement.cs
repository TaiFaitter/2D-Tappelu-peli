using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    
    private Rigidbody2D myRigidBody;
    private CircleCollider2D myFeet;
    private Animator animator;

    private LayerMask ground;

    public float speed = 5f;
    public float jumpForce = 7f;
    private float horizontalMovement = 0f;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        ground = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    // Ottaa koneen tehot huomioon päivitysnopeudessa
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && myFeet.IsTouchingLayers(ground))
        {
            // Impulse lisää kaiken voiman kerralla, jolloin se alkaa vähitellen vähentyä
            myRigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        if (myFeet.IsTouchingLayers(ground))
        {
            animator.SetBool("isTouchingGround", true);
        }
        else
        {
            animator.SetBool("isTouchingGround", false);
        }
    }

    // Ei ota huomioon koneen tehoja päivitysnopeudessa
    private void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(horizontalMovement * speed, myRigidBody.velocity.y);
        animator.SetFloat("speed", horizontalMovement);
    }
}
