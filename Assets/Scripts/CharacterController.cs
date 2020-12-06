using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float movementSpeed = 0.1f;
    public float jumpForce = 1f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.isPaused)
        {
            rb.simulated = false;
        }
        else
        {
            rb.simulated = true;

            //Moves the player forward at a constant rate
            transform.position = new Vector3(transform.position.x + movementSpeed, transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {   
        //Only allow player input controls when the game is NOT paused
        if(!GameController.isPaused)
        {
            //Pressing the space bar is jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, jumpForce));
                print("Jump");
            }
        }
    }
}
