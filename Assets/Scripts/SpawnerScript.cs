using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject prefab;
    public float spawnTime = 0;
    public float spawnRate = 5.0f;
    public GameObject[] spawnPoints;

    void Start()
    {
        spawnTime = 0;
    }

    void Update()
    {
        if (spawnTime >= spawnRate)
        {
            spawn();
        }
        else
        {
            spawnTime += Time.deltaTime;
        }
    }

    void spawn()
    {
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);       
        Instantiate(prefab, spawnPoints[randomSpawnPointIndex].transform.position, spawnPoints[randomSpawnPointIndex].transform.rotation);
        spawnTime = 0;
    }
}
