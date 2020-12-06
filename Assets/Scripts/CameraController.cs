using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Object to Lock on")]
    public GameObject player;

    [Header("Camera Controls")]
    public Vector3 offset = new Vector3(-4.5f, 0, 10);

    void Update()
    {
        //Tracks the player with the added offset to see forward more
        this.transform.position = new Vector3(player.transform.position.x + offset.x, offset.y, offset.z);
    }
}
