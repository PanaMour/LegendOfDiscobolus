using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemiesToSpawn = 5;
    public float activeEnemies = 0;
    public float totalEnemiesSpawned;
    public float enemiesAtOnce = 2;
    public float originRandomOffset = 2;
    public GameObject dragoncanvas;
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
        GameObject clone;
        if(enemyPrefab.gameObject.name=="SkeletonEnemy")
            clone = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0,0,0));
        else
        {
            clone = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 90, 0));
            dragoncanvas.SetActive(true);
            clone.gameObject.GetComponent<EnemyHealth>().healthBar = dragoncanvas.gameObject.transform.Find("Health").gameObject.GetComponent<Slider>();
        }


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