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
        GameObject clone = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0,90,0));

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
}