using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    
    private Rigidbody2D myRigidBody;
    private CircleCollider2D myFeet;

    private LayerMask ground;

    public float speed = 5f;
    public float jumpForce = 7f;
    private float horizontalMovement = 0f;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<CircleCollider2D>();
        ground = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    // Ottaa koneen tehot huomioon p‰ivitysnopeudessa
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && myFeet.IsTouchingLayers(ground))
        {
            // Impulse lis‰‰ kaiken voiman kerralla, jolloin se alkaa v‰hitellen v‰henty‰
            myRigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Ei ota huomioon koneen tehoja p‰ivitysnopeudessa
    private void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(horizontalMovement * speed, myRigidBody.velocity.y);
    }
}
