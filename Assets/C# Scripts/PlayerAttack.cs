using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private bool attacking = false;
    [SerializeField] private GameObject battleaxe;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && battleaxe.activeSelf && attacking == false)
        {
            attacking = true;
            animator.SetTrigger("Attack");
            
            StartCoroutine(Attacking());
        }
    }
    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(2f);
        attacking = false;
    }
}
