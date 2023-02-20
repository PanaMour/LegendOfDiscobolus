using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float totalHealth = 100f;
    [SerializeField] protected bool alive;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        alive = true;
        currentHealth = totalHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        if (!alive) return;

        currentHealth = Mathf.Max(currentHealth - damage, 0f);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        alive = false;
        Debug.Log("Death: " + name);
    }
}