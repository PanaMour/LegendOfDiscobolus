using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PeasantManController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    private bool walking;
    private Vector3 startPos;
    public float dis = 5f;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody= GetComponent<Rigidbody>();
        walking = true;
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        walking = this.gameObject.GetComponent<NPCInteraction>().isStopping;
        if (walking)
        {
            animator.Play("Walking");
            this.gameObject.GetComponent<PlayerNavMesh>().enabled = true;
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<PlayerNavMesh>().enabled = false;
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            transform.LookAt(playerTransform);
            animator.Play("Arguing");
        }
    }
}
