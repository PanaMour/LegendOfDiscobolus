using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject battleAxe;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackDamage = 10f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (battleAxe.activeSelf)
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                }
            }
        }
    }
}
