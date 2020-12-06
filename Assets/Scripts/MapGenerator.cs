using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject pipePrefab;

    [Header("Spawning Settings")]
    public int numPipes = 6;
    public float spacing = 4f;
    public float randHeightOffset = 1.5f;

    private float currentSpawnOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numPipes; i++)
        {
            float randHeight = 0;

            if (i != 0)
                randHeight = Random.Range(-randHeightOffset, randHeightOffset);

            GameObject currentPipe = Instantiate<GameObject>(pipePrefab);
            currentPipe.transform.position = new Vector3(currentPipe.transform.position.x + currentSpawnOffset, randHeight, currentPipe.transform.position.z);
            currentPipe.transform.parent = this.transform;

            currentSpawnOffset += spacing;
        }
    }

    public void SpawnPipe()
    {
        float randHeight = Random.Range(-randHeightOffset, randHeightOffset);

        GameObject currentPipe = Instantiate<GameObject>(pipePrefab);
        currentPipe.transform.position = new Vector3(currentPipe.transform.position.x + currentSpawnOffset, randHeight, currentPipe.transform.position.z);
        currentPipe.transform.parent = this.transform;

        currentSpawnOffset += spacing;
    }
}
