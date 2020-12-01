using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Object to Lock on")]
    public GameObject player;

    [Header("Camera Offset")]
    public Vector3 offset = new Vector3(-4.5f, 0, 10);

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x + offset.x, offset.y, offset.z);
    }
}
