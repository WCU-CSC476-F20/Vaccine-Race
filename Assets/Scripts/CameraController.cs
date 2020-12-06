using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Object to Lock on")]
    public GameObject player;

    [Header("Camera Controls")]
    public float spawnBuffer = 0.5f;
    public Vector3 offset = new Vector3(-4.5f, 0, 10);

    private BoxCollider2D spawnBounds;

    private void Awake()
    {
        spawnBounds = GameObject.FindGameObjectWithTag("Spawn Bounds").GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSpawnBounds();
    }

    void Update()
    {
        //Tracks the player with the added offset to see forward more
        this.transform.position = new Vector3(player.transform.position.x + offset.x, offset.y, offset.z);
    }

    private void SetSpawnBounds()
    {
        Camera mainCamera = Camera.main;
        spawnBounds.gameObject.transform.position = mainCamera.transform.position;

        spawnBounds.size = new Vector2(mainCamera.aspect * 2f * mainCamera.orthographicSize + spawnBuffer, 2f * mainCamera.orthographicSize + spawnBuffer);
    }
}
