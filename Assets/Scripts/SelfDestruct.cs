using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float distance;
    private MapGenerator mapGenerator;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        mapGenerator = GameObject.FindGameObjectWithTag("Map Generator").GetComponent<MapGenerator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        distance = transform.position.x - player.transform.position.x;

        if (distance <= mapGenerator.maxDistance)
        {
            if (tag == "Pipe Group")
                mapGenerator.SpawnPipe();

            Destroy(gameObject);
        }

    }
}
