using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Object to Lock on")]
    public GameObject player;

    [Header("Camera Controls")]
    public Vector3 offset = new Vector3(-4.5f, 0, 10);
    public float moveSpeed = 0.5f;

    void LateUpdate()
    {
        Vector3 cameraPos = new Vector3(player.transform.position.x + offset.x, offset.y, offset.z);

        //Tracks the player with the added offset to see forward more
        transform.position = Vector3.Lerp(transform.position, cameraPos, moveSpeed * Time.deltaTime);
    }
}
