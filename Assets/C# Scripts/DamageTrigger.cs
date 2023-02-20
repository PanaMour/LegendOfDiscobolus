using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other.gameObject);
    }

    void DealDamage(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Health foundHealth = other.GetComponentInParent<Health>();
            if (foundHealth != null)
            {
                foundHealth.TakeDamage(damage);
            }
        }
    }
}