using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Object to Lock on")]
    public GameObject player;

    [Header("Camera Controls")]
    public Vector3 offset = new Vector3(-4.5f, 0, 10);
    public float movementSpeed = 0.1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moves the player forward at a constant rate
        player.transform.position = new Vector3(player.transform.position.x + movementSpeed, player.transform.position.y, player.transform.position.z);
    }

    void Update()
    {
        //Tracks the player with the added offset to see forward more
        this.transform.position = new Vector3(player.transform.position.x + offset.x, offset.y, offset.z);
    }
}
