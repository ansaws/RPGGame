using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D playerBody;
    private Animator anim;
    Vector2 movement;
    private string direction = "d"; //d = down, u = up, l = left, r = right
    public int playerSpeed = 5;
    public bool isControlled = true;
    public bool onBoat = false;

    void Start()
    {
        //create rigidbody component and add it to player
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        playerBody.gravityScale = 0; //remove gravity (lol)

        //get animator component
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (isControlled)
        {
            move();
        }
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
            direction = "r";
        }
        else if (movement.x< 0)
        {
            anim.Play("Walk_left");
            direction = "l";
        }
        else if (movement.y > 0)
        {
            anim.Play("Walk_up");
            direction = "u";
        }
        else if (movement.y < 0)
        {
            anim.Play("Walk_down");
            direction = "d";
        }
        else
        {
            if (direction == "r")
            {
                anim.Play("Idle_right");
            }
            else if (direction == "l")
            {
                anim.Play("Idle_left");
            }
            else if (direction == "u")
            {
                anim.Play("Idle_up");
            }
            else if (direction == "d")
            {
                anim.Play("Idle_down");
            }
        }
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When collide with boat
        if(collision.gameObject.tag == "Boat")
        {
            //isControlled = false;//stop controlling the player
            movetoBoat(collision.gameObject);
            onBoat = true;//is on the boat
            collision.gameObject.GetComponent<Boat>().isControlled = true;//give control to the boat
        }
    }
    //move player on top of boat this is temp remove once we have actuall boat spites
    void movetoBoat(GameObject g)
    {
        gameObject.transform.position = new Vector3(g.transform.position.x, g.transform.position.y +1);
    }
}
