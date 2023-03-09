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
    public GameObject dragonCanvas;
    public float lootExplotionForce = 4f;
    public bool takingDamage = false;

    protected override void Start()
    {
        base.Start();
        dragonCanvas = GameObject.Find("DragonCanvas");
        UpdateUI();
        
    }

    public override void TakeDamage(float damage)
    {
        if(!takingDamage)
        {
            takingDamage = true;
            base.TakeDamage(damage);
            UpdateUI();
            animator.SetTrigger("Hit");
            StartCoroutine(TakingDamage());
        }
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
        animator.SetTrigger("Dead");
        animator.SetBool("Death",true);

        //DropLoot();

        //remove logic
        enabled = false; //enemyhealth
        GetComponentInParent<Enemy>().enabled = false;
        //GetComponentInParent<UnityEngine.AI.NavMeshAgent>().destination = transform.position;
        GetComponentInParent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        foreach (Collider collider in GetComponentsInChildren<Collider>())
        {
            Destroy(collider);
        }

        if (gameObject.transform.Find("SkeletonWarrior"))
            Destroy(GetComponentInChildren<Canvas>().gameObject);
        else
            dragonCanvas.SetActive(false);

        StartCoroutine(Despawn());
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

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    IEnumerator TakingDamage()
    {
        yield return new WaitForSeconds(2);
        takingDamage = false;
    }
}