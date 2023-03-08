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
    public GameObject dragoncanvas;
    public UnityEvent onSpawnerEnd;
    public GameObject skeleton;
    public GameObject playerDamage;
    public GameObject dragon;

    // Start is called before the first frame update
    void Start()
    {
        activeEnemies = 0;
        totalEnemiesSpawned = 0;

        if (enemiesToSpawn > 0) SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if(this.gameObject.name == "Spawner")
        {
            switch(GameManager.instance.currentDifficulty)
            {
                case GameManager.DifficultyLevel.Easy:
                    enemiesToSpawn = 3;
                    enemiesAtOnce = 1;
                    skeleton.transform.Find("DamageDealer").GetComponent<DamageTrigger>().damage = 5;
                    skeleton.transform.Find("DamageDealer").gameObject.SetActive(false);
                    playerDamage.GetComponent<DamageTriggerPlayer>().damage = 20;
                    break;
                case GameManager.DifficultyLevel.Medium:
                    enemiesToSpawn = 4;
                    enemiesAtOnce = 2;
                    skeleton.transform.Find("DamageDealer").GetComponent<DamageTrigger>().damage = 5;
                    skeleton.transform.Find("DamageDealer").gameObject.SetActive(false);
                    playerDamage.GetComponent<DamageTriggerPlayer>().damage = 20;
                    break;
                case GameManager.DifficultyLevel.Hard:
                    enemiesToSpawn = 7;
                    enemiesAtOnce = 3;
                    skeleton.transform.Find("DamageDealer").GetComponent<DamageTrigger>().damage = 10;
                    skeleton.transform.Find("DamageDealer").gameObject.SetActive(false);
                    playerDamage.GetComponent<DamageTriggerPlayer>().damage = 10;
                    break;
                case GameManager.DifficultyLevel.Impossible:
                    enemiesToSpawn = 10;
                    enemiesAtOnce = 5;
                    skeleton.transform.Find("DamageDealer").GetComponent<DamageTrigger>().damage = 25;
                    skeleton.transform.Find("DamageDealer").gameObject.SetActive(false);
                    playerDamage.GetComponent<DamageTriggerPlayer>().damage = 10;
                    break;
            }
        }
        else if(this.gameObject.name == "DragonSpawner")
        {
            switch (GameManager.instance.currentDifficulty)
            {
                case GameManager.DifficultyLevel.Easy:
                    enemiesToSpawn = 1;
                    enemiesAtOnce = 1;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealer").GetComponent<DamageTrigger>().damage = 5;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealerBody").GetComponent<DamageTrigger>().damage = 5;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealerNeck").GetComponent<DamageTrigger>().damage = 5;
                    dragon.transform.Find("DamageDealerAll").gameObject.SetActive(false);
                    playerDamage.GetComponent<DamageTriggerPlayer>().damage = 20;
                    break;
                case GameManager.DifficultyLevel.Medium:
                    enemiesToSpawn = 1;
                    enemiesAtOnce = 1;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealer").GetComponent<DamageTrigger>().damage = 10;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealerBody").GetComponent<DamageTrigger>().damage = 5;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealerNeck").GetComponent<DamageTrigger>().damage = 5;
                    dragon.transform.Find("DamageDealerAll").gameObject.SetActive(false);
                    playerDamage.GetComponent<DamageTriggerPlayer>().damage = 10;
                    break;
                case GameManager.DifficultyLevel.Hard:
                    enemiesToSpawn = 1;
                    enemiesAtOnce = 1;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealer").GetComponent<DamageTrigger>().damage = 20;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealerBody").GetComponent<DamageTrigger>().damage = 10;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealerNeck").GetComponent<DamageTrigger>().damage = 10;
                    dragon.transform.Find("DamageDealerAll").gameObject.SetActive(false);
                    playerDamage.GetComponent<DamageTriggerPlayer>().damage = 10;
                    break;
                case GameManager.DifficultyLevel.Impossible:
                    enemiesToSpawn = 2;
                    enemiesAtOnce = 1;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealer").GetComponent<DamageTrigger>().damage = 50;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealerBody").GetComponent<DamageTrigger>().damage = 15;
                    dragon.transform.Find("DamageDealerAll").transform.Find("DamageDealerNeck").GetComponent<DamageTrigger>().damage = 15;
                    dragon.transform.Find("DamageDealerAll").gameObject.SetActive(false);
                    playerDamage.GetComponent<DamageTriggerPlayer>().damage = 5;
                    break;
            }
        }
        activeEnemies++;
        totalEnemiesSpawned++;
        GameObject clone;
        if(enemyPrefab.gameObject.name=="SkeletonEnemy")
            clone = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0,0,0));
        else
        {
            clone = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 90, 0));
            if(GameManager.instance.currentDifficulty == GameManager.DifficultyLevel.Impossible)
            {
                StartCoroutine(Wait2SecDragon());
            }
            else
            {
                dragoncanvas.SetActive(true);
            }
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
            StartCoroutine(Wait2Sec());
        }
    }

    public void NotifyDeath(EnemyHealth enemyHealth)
    {
        activeEnemies--;

        if (totalEnemiesSpawned < enemiesToSpawn)
        {
            SpawnEnemy();
        }
        else if(activeEnemies== 0)
        {
            onSpawnerEnd.Invoke();
        }
    }

    IEnumerator Wait2Sec()
    {
        yield return new WaitForSeconds(2);
        SpawnEnemy();
    }

    IEnumerator Wait2SecDragon()
    {
        yield return new WaitForSeconds(2);
        dragoncanvas.SetActive(true);
    }
}