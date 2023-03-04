using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [Space]
    [Header("Player Health properties")]
    [Space]
    [SerializeField] bool immune;
    [SerializeField] Slider healthBar;
    [SerializeField] Animator animator;

    protected override void Start()
    {
        base.Start();

        immune = false;

        healthBar.value = currentHealth / totalHealth;
    }

    public override void TakeDamage(float damage)
    {
        if (!alive) return;

        if (immune) return;

        //currentHealth -= damage;
        //if (currentHealth < 0) currentHealth = 0;

        currentHealth = Mathf.Max(currentHealth - damage, 0f);

        healthBar.value = currentHealth / totalHealth;

        animator.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float value)
    {
        currentHealth = Mathf.Min(currentHealth + value, totalHealth);

        healthBar.value = currentHealth / totalHealth;
    }

    protected override void Die()
    {
        base.Die();

        Debug.Log("Game Over");

       animator.SetTrigger("Death");

        foreach (Component component in GetComponentsInChildren<Component>())
        {
            if (component.GetType() != typeof(SkinnedMeshRenderer)
                && component.GetType() != typeof(Transform)
                && component.GetType() != typeof(Animator)
               )
            {
                Debug.Log(component.ToString());
                Destroy(component);
            }
        }

        foreach (Enemy enemy in GameObject.FindObjectsOfType<Enemy>())
        {
            enemy.LostPlayer(gameObject);
        }
        GameObject.FindObjectsOfType<Enemy>();        
    }
}