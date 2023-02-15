using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PeasantGirlController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    private bool idle;
    public float dis = 5f;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
        idle = this.gameObject.GetComponent<NPCInteraction>().isStopping;
        if (idle)
        {
            animator.Play("Idle");
        }
        else
        {
            transform.LookAt(playerTransform);
            animator.Play("Talking");
        }
    }
}
