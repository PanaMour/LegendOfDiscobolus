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
    private Vector3 stopPosition;
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
            /*if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
            {
                transform.position = stopPosition;
            }*/
            animator.Play("Walking");
            this.gameObject.GetComponent<PlayerNavMesh>().enabled = true;
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            /*transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, Time.deltaTime * 1f);

            if (Vector3.Distance(transform.position, startPos) >= dis)
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f) * transform.rotation;
                startPos = transform.position;
            }*/
        }
        else
        {
            this.gameObject.GetComponent<PlayerNavMesh>().enabled = false;
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            //stopPosition = transform.position;
            transform.LookAt(playerTransform);
            animator.Play("Arguing");
        }
    }
}
