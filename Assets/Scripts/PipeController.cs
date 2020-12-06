using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    private MapGenerator mapGenerator;

    // Start is called before the first frame update
    void Start()
    {
        mapGenerator = GetComponentInParent<MapGenerator>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Spawns a new pipe when it goes out of bounds and destroys itself
        if(collision.CompareTag("Spawn Bounds"))
        {
            mapGenerator.SpawnPipe();

            Destroy(gameObject);
        }
    }
}
