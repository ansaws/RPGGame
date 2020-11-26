using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public Rigidbody2D body;
    public bool isControlled = false;
    private Vector2 movement;
    public int boatSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        //Set Rigidbody
        body = gameObject.GetComponent<Rigidbody2D>();
        body.gravityScale = 0;//Turn off Gravity
    }

    // Update is called once per frame
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
        body.MovePosition(body.position + movement * boatSpeed * Time.fixedDeltaTime);//Move the player
    }
}
