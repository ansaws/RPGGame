using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D playerBody;
    Vector2 movement;
    public int playerSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    }
}
