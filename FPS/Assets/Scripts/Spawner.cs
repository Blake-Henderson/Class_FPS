using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public GameObject go;
    public bool active;

    public Enemy(GameObject theGo, bool shouldBeActive)
    {
        go = theGo;
        active = shouldBeActive;
    }
}

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int numToSpawn = 1;
    public float spawnDelay = 1.0f;

    int getAmount = 0;
    int enemyDead = 0;

    float timer = 0.0f;
    int spawned = 0;

    [HideInInspector]
    public bool spawnsDead = false;

    public List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
        GameManager.RoundComplete += ResetRound;
        ResetRound();

        while (spawned < getAmount)
        {
            ++spawned;
            GameObject instance = Instantiate(prefabToSpawn, transform);
            enemies.Add(new Enemy(instance, false));
            instance.transform.parent = null;
            instance.SetActive(false);
        }

        ResetRound();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnDelay)
        {
            if (spawned < numToSpawn)
            {
                timer -= spawnDelay;
                enemies[spawned].active = true;
                enemies[spawned].go.SetActive(true);
                StartCoroutine(SetKinematic(spawned));
                ++spawned;
            }
        }

        for (int i = enemies.Count - 1; i >= 0; --i)
        {
            if (enemies[i].go.activeSelf == false && enemies[i].active == true)
            {
                enemies[i].go.transform.position = transform.position;
                enemies[i].active = false;
                ++enemyDead;
            }
        }

        if (enemyDead == enemies.Count)
        {
            spawnsDead = true;
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

    public void ResetRound()
    {
        spawnsDead = false;
        getAmount = numToSpawn;
        spawned = 0;
        timer = 0.0f;
        enemyDead = 0;
    }

    IEnumerator SetKinematic(int enemyIndex)
    {
        yield return null;
        enemies[enemyIndex].go.GetComponent<Rigidbody>().isKinematic = true;
    }
}
