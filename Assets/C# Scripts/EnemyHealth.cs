using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health
{
    private Spawner myParentSpawner;
    public Slider healthBar;
    public Animator animator;
    public GameObject[] loots;
    public float lootExplotionForce = 4f;

    protected override void Start()
    {
        base.Start();

        UpdateUI();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        UpdateUI();

        //hit animation
        //animator.SetTrigger("Hit");
    }

    void UpdateUI()
    {
        healthBar.value = currentHealth / totalHealth;
    }

    public void RegisterSpawner(Spawner myParentSpawner)
    {
        this.myParentSpawner = myParentSpawner;
    }

    protected override void Die()
    {
        base.Die();

        myParentSpawner.NotifyDeath(this);

        //animator.SetTrigger("Death");

        DropLoot();

        //remove logic
        enabled = false; //enemyhealth
        GetComponentInParent<Enemy>().enabled = false;
        GetComponentInParent<UnityEngine.AI.NavMeshAgent>().destination = transform.position;
        GetComponentInParent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        foreach (Collider collider in GetComponentsInChildren<Collider>())
        {
            Destroy(collider);
        }

        Destroy(GetComponentInChildren<Canvas>().gameObject);
        //Destroy(gameObject);
    }

    void DropLoot()
    {
        foreach (GameObject item in loots)
        {
            Quaternion randomRot = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
            GameObject clone = Instantiate(item, transform.position, randomRot);

            Vector3 randomExplosionPos = clone.transform.position;
            randomExplosionPos.x += Random.Range(-0.01f, 0.01f);
            randomExplosionPos.y += Random.Range(-0.02f, -0.01f);
            randomExplosionPos.z += Random.Range(-0.01f, 0.01f);

            clone.GetComponent<Rigidbody>().AddExplosionForce(lootExplotionForce, randomExplosionPos, lootExplotionForce, 0f, ForceMode.Impulse);
        }
    }
}