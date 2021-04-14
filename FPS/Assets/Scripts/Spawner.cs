using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int numToSpawn = 1;
    public float spawnDelay = 1.0f;

    float timer = 0.0f;
    int spawned = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnDelay)
        {
            if (spawned < numToSpawn)
            {
                ++spawned;
                timer -= spawnDelay;
                GameObject instance = Instantiate(prefabToSpawn, transform);
                instance.transform.parent = null;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (prefabToSpawn != null)
        {
            Gizmos.DrawWireMesh(prefabToSpawn.GetComponent<MeshFilter>().sharedMesh, transform.position, transform.rotation, Vector3.one);
        }
    }
}
