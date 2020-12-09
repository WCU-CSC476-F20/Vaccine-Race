using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float movementSpeed = 0.1f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private GameController gameController;
    private MapGenerator mapGenerator;
    private bool jump;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Game Controller").GetComponent<GameController>();
        mapGenerator = GameObject.FindGameObjectWithTag("Map Generator").GetComponent<MapGenerator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameController.isPaused)
        {
            rb.simulated = false;
        }
        else
        {
            rb.simulated = true;

            //Moves the player forward at a constant rate
            rb.position = new Vector3(transform.position.x + movementSpeed, transform.position.y, transform.position.z);

            if (jump)
            {
                jump = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    private void Update()
    {
        //Only allow player input controls when the game is NOT paused
        if (!gameController.gameOver)
        {
            //Pressing the space bar is jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameController.isPaused = false;
                gameController.startUI.SetActive(false);
                jump = true;
            }
        }
    }

    //Runs when the player hits certain objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Point"))
        {
            gameController.score++;

            if(gameController.score % mapGenerator.difficultyLevel == 0 && gameController.score != 0 && mapGenerator.spacing > 4)
            {
                mapGenerator.spacing -= mapGenerator.difficulty;
            }
        }
        else if(collision.CompareTag("Pipe"))
        {
            gameController.RestartLevel();
        }
        else if(collision.CompareTag("Pickup"))
        {
            gameController.PlayerCoins();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Spawn Bounds"))
        {
            gameController.RestartLevel();
        }
    }
}
