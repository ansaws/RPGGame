using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D playerBody;
    private Animator anim;
    Vector2 movement;
    public int playerSpeed = 5;


    void Start()
    {
        //create rigidbody component and add it to player
        playerBody = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        playerBody.gravityScale = 0; //remove gravity (lol)

        //get animator component
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        move();
    }
    void move()
    {
        //Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        playerBody.MovePosition(playerBody.position + movement * playerSpeed * Time.fixedDeltaTime); //move the player
        
        //animation
        if (movement.x > 0)
        {
            anim.Play("Walk_right");
        }
        else if (movement.x< 0)
        {
            anim.Play("Walk_left");
        }
        else if (movement.y > 0)
        {
            anim.Play("Walk_up");
        }
        else if (movement.y < 0)
        {
            anim.Play("Walk_down");
        }
        else
        {
            anim.Rebind();
        }
    }
}
