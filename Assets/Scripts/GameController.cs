using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Game Settings")]
    public static bool isPaused = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Pauses the game
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;
    }
}
