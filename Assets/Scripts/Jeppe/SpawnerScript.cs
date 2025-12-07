using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject prefab;
    private float spawnTime = 0;
    public float spawnRate = 5.0f;
    public GameObject[] spawnPoints;
    public float gameTime;

    public static SpawnerScript instance;
    void Start()
    {
        // Sørger for at spawnTime og gameTime bliver sat til noget og skaber en instance af spawnerscriptet, der kan tilgås fra andre scripts.
        spawnTime = 0;
        gameTime = 0;
        instance = this;
    }

    void Update()
    {
        // hvis spawntime >= spawnrate, så køres spawn() metoden, der er længere nede. Ellers tilføres der tid til timeren.
        if (spawnTime >= spawnRate)
        {
            spawn();
        }
        else
        {
            spawnTime += Time.deltaTime;
        }
        gameTime += Time.deltaTime;
    }

    void spawn()
    {
        //Her gemmer vi en variable randomSpawnPointIndex, som får en tilfældig værdi mellem 0 længden af spawnPoints arrayet.
        //Derefter instantierer vi prefab objektet ved den tilfældige spawn point's position og rotation.
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);       
        Instantiate(prefab, spawnPoints[randomSpawnPointIndex].transform.position, spawnPoints[randomSpawnPointIndex].transform.rotation);
        spawnTime = 0;
    }
}
