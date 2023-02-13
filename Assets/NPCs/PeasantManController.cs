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
        if (walking)
        {
            animator.Play("Walking");
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, Time.deltaTime * 1f);

            if (Vector3.Distance(transform.position, startPos) >= dis)
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f) * transform.rotation;
                startPos = transform.position;
            }
        }
        else
        {
            animator.Play("Arguing");
        }
    }
}
