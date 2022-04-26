using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class Movement : MonoBehaviour
{

    PhotonView view;
    private Rigidbody2D myRigidBody;
    private CircleCollider2D myFeet;
    private Animator animator;

    private LayerMask ground;

    public float facing = 1f;

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
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    // Ottaa koneen tehot huomioon p‰ivitysnopeudessa
    void Update()
    {
        bool isHit = GetComponent<Health>().isHit;
        if (view.IsMine && !isHit)
        {
            horizontalMovement = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && myFeet.IsTouchingLayers(ground))
            {
                // Impulse lis‰‰ kaiken voiman kerralla, jolloin se alkaa v‰hitellen v‰henty‰
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

    }

    // Ei ota huomioon koneen tehoja p‰ivitysnopeudessa
    private void FixedUpdate()
    {
        bool isHit = GetComponent<Health>().isHit;
        if (view.IsMine && !isHit)
        {
            myRigidBody.velocity = new Vector2(horizontalMovement * speed, myRigidBody.velocity.y);
            animator.SetFloat("speed", Mathf.Abs(horizontalMovement));
        }
    }
}
