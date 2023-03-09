using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTriggerPlayer : MonoBehaviour
{
    public float damage = 10f;
    public GameObject damagedealer;
    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other.gameObject);
    }

    void DealDamage(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health foundHealth = other.GetComponentInParent<Health>();
            if (foundHealth != null)
            {
                foundHealth.TakeDamage(damage);
            }
        }
    }
}
