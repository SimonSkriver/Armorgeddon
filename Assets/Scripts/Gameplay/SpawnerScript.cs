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
        // Soerger for at spawnTime og gameTime bliver sat til noget og skaber en instance af spawnerscriptet, der kan tilg�s fra andre scripts.
        spawnTime = 0;
        gameTime = 0;
        instance = this;
    }

    void Update()
    {
        // hvis spawntime >= spawnrate, saa koeres spawn() metoden, der er laengere nede. Ellers tilfoeres der tid til timeren.
        if (spawnTime >= spawnRate)
        {
            Spawn();
        }
        else
        {
            spawnTime += Time.deltaTime;
        }
        gameTime += Time.deltaTime;
    }

    void Spawn()
    {
        //Her gemmer vi en variable randomSpawnPointIndex, som faar en tilfaeldig vaerdi mellem 0 laengden af spawnPoints arrayet.
        //Derefter instantierer vi prefab objektet ved den tilfaeldige spawn point's position og rotation.
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);       
        Instantiate(prefab, spawnPoints[randomSpawnPointIndex].transform.position, spawnPoints[randomSpawnPointIndex].transform.rotation);
        spawnTime = 0;
    }
}
