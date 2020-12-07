using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject pipePrefab;
    public GameObject pickupPrefab;

    [Header("Pipe Spawning Settings")]
    public int numPipes = 6;
    public float spacing = 4f;
    public float randHeightOffset = 1.5f;
    public float maxDistance = 10f;

    [Header("Pickup Spawning Settings")]
    public float randPickupSpawnChance = 0.35f;
    public Vector2 randPosOffset = new Vector2(0.5f, 1f);

    private float currentSpawnOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numPipes; i++)
        {
            if (i == 0)
                SpawnPipeNotRandom();
            else
                SpawnPipe();
        }
    }

    public void SpawnPipeNotRandom()
    {
        GameObject currentPipe = Instantiate<GameObject>(pipePrefab, this.transform);
        currentPipe.transform.position = new Vector3(currentPipe.transform.position.x + currentSpawnOffset, 0, currentPipe.transform.position.z);

        currentSpawnOffset += spacing;
    }

    public void SpawnPipe()
    {
        float randHeight = Random.Range(-randHeightOffset, randHeightOffset);

        GameObject currentPipe = Instantiate<GameObject>(pipePrefab, this.transform);
        currentPipe.transform.position = new Vector3(currentPipe.transform.position.x + currentSpawnOffset, randHeight, currentPipe.transform.position.z);

        if(Random.value <= randPickupSpawnChance)
        {
            randHeight = Random.Range(-randPosOffset.y, randPosOffset.y);
            float randDist = Random.Range(-randPosOffset.x, randPosOffset.y);

            GameObject pickupObject = Instantiate(pickupPrefab);
            pickupObject.transform.position = new Vector3((currentPipe.transform.position.x + (spacing / 2f)) + randDist, randHeight, currentPipe.transform.position.z);
        }

        currentSpawnOffset += spacing;
    }
}
