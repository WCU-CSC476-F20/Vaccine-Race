using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Game Settings")]
    public float spawnBuffer = 0.5f;
    public static bool isPaused = true;

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

    // Update is called once per frame
    void Update()
    {
        //Pauses the game
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;
    }

    private void SetSpawnBounds()
    {
        Camera mainCamera = Camera.main;
        spawnBounds.gameObject.transform.position = mainCamera.transform.position;

        spawnBounds.size = new Vector2(mainCamera.aspect * 2f * mainCamera.orthographicSize + spawnBuffer, 2f * mainCamera.orthographicSize + spawnBuffer);
    }
}
