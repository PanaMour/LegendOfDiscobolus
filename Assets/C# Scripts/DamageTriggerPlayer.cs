using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTriggerPlayer : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

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
