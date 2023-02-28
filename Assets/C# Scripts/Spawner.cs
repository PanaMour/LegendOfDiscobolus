using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemiesToSpawn = 5;
    public float activeEnemies = 0;
    public float totalEnemiesSpawned;
    public float enemiesAtOnce = 2;
    public float originRandomOffset = 2;
    public UnityEvent onSpawnerEnd;

    // Start is called before the first frame update
    void Start()
    {
        activeEnemies = 0;
        totalEnemiesSpawned = 0;

        if (enemiesToSpawn > 0) SpawnEnemy();
    }

    void SpawnEnemy()
    {
        activeEnemies++;
        totalEnemiesSpawned++;

        GameObject clone = Instantiate(enemyPrefab, RandomSpawnPosition(), new Quaternion(-90,0,0,0));

        //POSITION
        //clone.transform.position = RandomSpawnPosition();

        EnemyHealth enemyHealth = clone.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.RegisterSpawner(this);
        }

        if (activeEnemies < enemiesAtOnce)
        {
            SpawnEnemy();
        }
    }

    public void NotifyDeath(EnemyHealth enemyHealth)
    {
        activeEnemies--;

        if (totalEnemiesSpawned < enemiesToSpawn)
        {
            SpawnEnemy();
        }
        else
        {
            onSpawnerEnd.Invoke();
        }
    }

    Vector3 RandomSpawnPosition()
    {
        /*float x = Random.Range(transform.position.x - originRandomOffset, transform.position.x + originRandomOffset);
        float z = Random.Range(transform.position.z - originRandomOffset, transform.position.z + originRandomOffset);*/
        Debug.Log(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        return new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}